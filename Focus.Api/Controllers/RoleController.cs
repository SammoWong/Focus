using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Focus.Api.Middlewares;
using Focus.Application;
using Focus.Infrastructure.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Role")]
    public class RoleController : FocusControllerBase
    {
        private readonly RoleAppService _roleAppService;

        public RoleController()
        {
            _roleAppService = IoCConfig.Get<RoleAppService>();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleAppService.GetAllAsync();
            var result = await ExecuteAsync(async () => await (_roleAppService.GetAllAsync()));
            return Ok(result);
            //return Ok(new StandardJsonResult<List<Domain.Entities.Role>> { Data = result.ToList(), State = true });
            //return Ok(await _roleAppService.GetAllAsync());
        }
    }
}