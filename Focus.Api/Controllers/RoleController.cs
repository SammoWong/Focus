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
    [Authorize]
    public class RoleController : FocusControllerBase
    {
        private readonly RoleAppService _roleAppService;

        public RoleController()
        {
            _roleAppService = IoCConfig.Get<RoleAppService>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var roles = await _roleAppService.GetAllAsync();
            return Ok(new StandardResult().Succeed(null, roles));
        }
    }
}