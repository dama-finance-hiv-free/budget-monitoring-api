using System.Security.Claims;
using Dama.Fin.Domain.Contracts.Service.Common;
using Microsoft.AspNetCore.Http;

namespace Dama.Fin.API.Services;

public class LoggedInUserService : ILoggedInUserService
{
    public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
    {
        UserId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    public string UserId { get; }
}