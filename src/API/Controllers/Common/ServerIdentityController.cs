using System;
using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Common;


public class ServerIdentityController : ApiControllerBase 
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return await GetActionResult(() =>
        {
            var osInfo = new
            {
                machineName = Environment.MachineName
            };

            return Task.FromResult<IActionResult>(Ok(osInfo));
        });
    }
}