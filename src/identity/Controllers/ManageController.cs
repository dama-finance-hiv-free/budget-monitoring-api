using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityProvider.Core;
using IdentityProvider.Data.Entity;
using IdentityProvider.Models;
using IdentityProvider.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace IdentityProvider.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ManageController : ApiControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IEmailSenderService _emailSender;
    private readonly ISmsService _smsService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ManageController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
        IEmailSenderService emailSender, ISmsService smsService, IWebHostEnvironment webHostEnvironment)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailSender = emailSender;
        _smsService = smsService;
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
    {
        var response = new ApiResponse();

        if (!ModelState.IsValid)
        {
            response.Success = false;

            ReadValidationErrors(response);

            return Ok(response);
        }

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user != null)
        {
            //var origin = Request.Headers["origin"];
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var forgotUrl = $"api/account/reset-password?token={token}&email={user.Email}";

            await System.IO.File.WriteAllTextAsync("forgotLink.txt", forgotUrl);
            response.Message = "reset link sent to your email address";
        }
        else
        {
            // email user and inform them that they do not have an account
            response.Success = false;
            response.Message = "your request is invalid";
            return BadRequest(response);
        }

        response.Success = true;
        return Ok(response);
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
    {

        var response = new ApiResponse();

        if (!ModelState.IsValid)
        {
            response.Success = false;
            ReadValidationErrors(response);
            return BadRequest(response);
        }

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user != null)
        {
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                response.Success = false;

                ReadValidationErrors(response);

                return BadRequest(response);
            }

            if (await _userManager.IsLockedOutAsync(user))
            {
                await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow);
            }

            response.Message = "password changed successfully";
            response.Success = true;
            return Ok(response);
        }

        ModelState.AddModelError("", "Invalid Request");
        response.Success = false;

        ReadValidationErrors(response);

        return BadRequest(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        var response = new ApiResponse();

        if (!ModelState.IsValid)
        {
            response.Success = false;
            ReadValidationErrors(response);
            return BadRequest(response);
        }

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user != null)
        {
            //user email already taken
            ModelState.AddModelError("", "User already registered with this email");
            response.Success = false;
            ReadValidationErrors(response);
            return BadRequest(response);
        }

        var lastReference = _userManager.Users.Max(x => x.UserCode);
        var serial = lastReference == null
            ? "1".ToFiveChar()
            : (lastReference.ToNumValue() + 1)
            .ToNumValue().ToString(CultureInfo.InvariantCulture).ToFiveChar();
        
        user = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = model.Email,
            FullName = model.FullName,
            Locale = model.Locale,
            PhoneNumber = model.PhoneNumber,
            Email = model.Email,
            Organization = model.Organization,
            UserCode = serial
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            response.ValidationErrors = new List<string>();
            foreach (var error in result.Errors)
            {
                if (!ModelState.Keys.Contains(error.Code))
                    ModelState.AddModelError(error.Code, error.Description);
            }

            ReadValidationErrors(response);

            response.Success = false;
            return BadRequest(response);
        }

        var claims = new List<Claim>
        {
            new Claim(JwtClaimTypes.Email, user.Email),
        };
        if (model.Role.Length > 0)
        {
            claims.Add(new Claim(JwtClaimTypes.Role,model.Role));
        }

        //var clearResults = _userManager?.RemoveClaimsAsync(user, claims);

        var claimsResult = await _userManager?.AddClaimsAsync(user, claims)!;

        if (result.Succeeded)
        {
            var confirmEmailModel = new ConfirmEmailModel
            {
                Email = model.Email,
            };

            await SendEmailConfirmationAsync(confirmEmailModel);

            response.Success = true;
            response.Message = "account created successfully";
            return Ok(response);
        }

        foreach (var error in result.Errors)
        {
            if (!ModelState.Keys.Contains(error.Code))
                ModelState.AddModelError(error.Code, error.Description);
        }

        ReadValidationErrors(response);

        response.Success = false;
        return BadRequest(response);
    }

    private async Task SendEmailConfirmationAsync(ConfirmEmailModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var confirmationEmailLink = $"{model.Origin}/account/confirm-email?token={token}&email={user.Email}";

        string[] paths = { _webHostEnvironment.WebRootPath, "templates", "mail.htm" };
        var fullPath = Path.Combine(paths);

        string body;

        using (var reader = new StreamReader(fullPath))
        {
            body = await reader.ReadToEndAsync();
        }

        body = body.Replace("{Url}", confirmationEmailLink).Replace("{UserName}", user.FullName); //replacing the required things  

        var userEmailOptions = new UserEmailOptions
        {
            Body = body,
            Subject = "Verify Email",
            ToEmails = new List<string>() { user.Email }
        };

        await _emailSender.SendEmailAsync(userEmailOptions);
        //await System.IO.File.WriteAllTextAsync("confirmationLink.txt", confirmationEmailLink);
    }

    [HttpPost("confirm-email")]
    public async Task<IActionResult> ConfirmEmail(ConfirmEmailModel model)
    {
        var response = new ApiResponse();

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (await _userManager.IsEmailConfirmedAsync(user))
        {
            response.Success = true;
            response.Message = "your email address is already verified!";
            return Ok(response);
        }

        if (user != null)
        {
            var result = await _userManager.ConfirmEmailAsync(user, model.Token);

            if (result.Succeeded)
            {
                response.Message = "email verified successfully";
                return Ok(response);
            }
        }

        response.Message = "invalid request";
        return BadRequest(response);
    }

    [HttpPost("confirm-email-request")]
    public async Task<IActionResult> ConfirmEmailRequest(ConfirmEmailRequestModel model)
    {
        var response = new ApiResponse();

        if (!ModelState.IsValid)
        {
            response.Success = false;
            return BadRequest(response);
        }

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            response.Success = false;
            response.Message = "invalid request";
            return BadRequest(response);
        }

        var confirmEmailModel = new ConfirmEmailModel
        {
            Email = model.Email,
            Origin = model.Origin
        };

        await SendEmailConfirmationAsync(confirmEmailModel);

        response.Success = true;
        response.Message = "we have sent you an email.";

        return Ok(response);

    }

    [HttpPost("confirm-phone-number-request")]
    public async Task<IActionResult> ConfirmPhoneNumberRequest(ConfirmPhoneNumberRequestModel model)
    {
        var response = new ApiResponse();

        if (!ModelState.IsValid)
        {
            response.Success = false;
            ReadValidationErrors(response);
            return BadRequest(response);
        }

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            response.Success = false;
            response.Message = "invalid request";
            ReadValidationErrors(response);
            return BadRequest(response);
        }

        var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");

        await HttpContext.SignInAsync(IdentityConstants.TwoFactorUserIdScheme,
            Store2Fa(user.Id, "Email"));

        var userSmsOptions = new UserSmsOptions
        {
            Body = $"You verification code for dama finance is {token}",
            Destination = user.PhoneNumber
        };

        var result = await _smsService.SendSmsAsync(userSmsOptions);

        if (!result.IsSuccessful)
        {
            ReadValidationErrors(response);
            return Ok(response);
        }

        response.Success = true;
        response.Message = "we have sent you an sms.";
        return Ok(response);
    }

    [HttpPost("confirm-phone-number")]
    public async Task<IActionResult> ConfirmPhoneNumber(ConfirmPhoneNumberModel model)
    {
        var response = new ApiResponse();

        var result = await HttpContext.AuthenticateAsync(IdentityConstants.TwoFactorUserIdScheme);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "You login request has expired, please start over");
            ReadValidationErrors(response);
            return BadRequest(response);
        }

        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(result.Principal.FindFirstValue("sub"));

            if (user != null)
            {
                var isValid = await _userManager.VerifyTwoFactorTokenAsync(user,
                    result.Principal.FindFirstValue("amr"), model.Token);

                if (isValid)
                {
                    await HttpContext.SignOutAsync(IdentityConstants.TwoFactorUserIdScheme);

                    //var claimsPrincipal = await _claimsPrincipalFactory.CreateAsync(user);
                    //await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, claimsPrincipal);

                    response.Message = "phone number cofirmed successfully";
                    return BadRequest(response);
                }

                ModelState.AddModelError("", "Invalid token");
                ReadValidationErrors(response);
                return BadRequest(response);
            }

            ModelState.AddModelError("", "Invalid Request");
            ReadValidationErrors(response);
        }

        return BadRequest(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        var response = new LoginResponse();

        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null && !await _userManager.IsLockedOutAsync(user))
            {
                if (await _signInManager.CheckPasswordSignInAsync(user, model.Password, true) == SignInResult.Success)
                {
                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError("", "Email is not confirmed");
                        ReadValidationErrors(response);
                        response.Success = false;
                        return BadRequest(response);
                    }

                    var currentUser = new UserVm
                    {
                        Email = user.Email,
                        UserName = user.UserName,
                        PhoneNumber = user.PhoneNumber,
                        FullName = user.FullName,
                        Locale = user.Locale,
                    };

                    await _userManager.ResetAccessFailedCountAsync(user);

                    response.Success = true;
                    response.Message = "login successful";
                    response.CurrentUser = currentUser;

                    return Ok(response);
                }

                await _userManager.AccessFailedAsync(user);

                if (await _userManager.IsLockedOutAsync(user))
                {
                    // email user, notifying them of lockout
                }
            }

            ModelState.AddModelError("", "Invalid UserName or Password");
            ReadValidationErrors(response);
            response.Success = false;

        }

        return BadRequest(response);
    }

    [HttpGet("send-sms")]
    public async Task<IActionResult> SendMessage()
    {
        var response = new ApiResponse();

        var userSmsOptions = new UserSmsOptions
        {
            Body = "You verification code for dama finance is 044856",
            Destination = "677294730"
        };

        var result = await _smsService.SendSmsAsync(userSmsOptions);

        if (result.IsSuccessful)
        {
            response.Success = true;
            response.Message = "we have sent you an sms.";
            return Ok(response);
        }

        response.Success = false;
        response.Message = "sms sending failed";
        return Ok(response);

    }

    private static ClaimsPrincipal Store2Fa(string userId, string provider)
    {
        var identity = new ClaimsIdentity(new List<Claim>
        {
            new Claim("sub", userId),
            new Claim("amr", provider)
        }, IdentityConstants.TwoFactorUserIdScheme);

        return new ClaimsPrincipal(identity);
    }
}