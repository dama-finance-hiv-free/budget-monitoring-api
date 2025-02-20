using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dama.Core.Common.Core;
using Dama.Core.Common.Exceptions;
using Dama.Fin.Domain.Vm;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Core;

[Route("api/[controller]")]
[ApiController]
public class ApiControllerBase : ControllerBase
{
    protected async Task<IActionResult> GetActionResult(Func<Task<IActionResult>> codeToExecute)
    {
        try
        {
            return await codeToExecute.Invoke();
        }
        catch (ValidationException ex)
        {
            var validationErrors = ex.ValidationErrors;
            var i = 1;
            foreach (var validationError in validationErrors)
            {
                ModelState.AddModelError(i.ToString(),validationError);
                i++;
            }
            return ValidationProblem();
        }
    }

    protected CurrentUserVm GetCurrentUser()
    {
        var currentUser = new CurrentUserVm();
        var claimsPrincipal = HttpContext.User.Identity as ClaimsIdentity;
        currentUser.Code = claimsPrincipal?.Claims.FirstOrDefault(c => c.Type == "user_map")?.Value;
        currentUser.Telephone = claimsPrincipal?.Claims.FirstOrDefault(c => c.Type == "user_telephone")?.Value;
        currentUser.Email = claimsPrincipal?.Claims.FirstOrDefault(c => c.Type == "user_email")?.Value;
        currentUser.Tenant = claimsPrincipal?.Claims.FirstOrDefault(c => c.Type == "user_organization")?.Value;
        currentUser.ImageUrl = claimsPrincipal?.Claims.FirstOrDefault(c => c.Type == "user_avatar")?.Value;
        currentUser.Name = claimsPrincipal?.Claims.FirstOrDefault(c => c.Type == "user_fullname")?.Value;
        currentUser.Subject = claimsPrincipal?.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

        return currentUser;
    }

}