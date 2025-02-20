using System.Linq;
using System.Threading.Tasks;
using IdentityProvider.Core;
using IdentityProvider.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityProvider.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "token")]
public class UsersController : ApiControllerBase
{
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Users(string code)
    {
        return await GetActionResult(async () =>
        {
            var users = await _context.Users.Select(x => new
            {
                fullName = x.FullName,
                organization = x.Organization,
                Locale = x.Locale,
                userCode = x.UserCode,
                imageUrl = x.ImageUrl,
                email = x.Email,
                emailConfirmed = x.EmailConfirmed,
                phoneNumber = x.PhoneNumber,
                phoneNumberConfirmed = x.PhoneNumberConfirmed,
                twoFactorEnabled = x.TwoFactorEnabled,
            }).ToArrayAsync();

            return Ok(users);
        });
    }
}