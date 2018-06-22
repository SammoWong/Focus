using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Focus.Api.Middlewares;
using Focus.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Role")]
    public class RoleController : Controller
    {
        private readonly RoleAppService _roleAppService;

        public RoleController()
        {
            _roleAppService = IoCConfig.Get<RoleAppService>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roleAppService.GetAllAsync());
        }
    }
}