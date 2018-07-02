using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Focus.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Module")]
    public class ModuleController : Controller
    {
        private readonly ModuleAppService _moduleAppService;
        public ModuleController(ModuleAppService moduleAppService)
        {
            _moduleAppService = moduleAppService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok();
        }
    }
}