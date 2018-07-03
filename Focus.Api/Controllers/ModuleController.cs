using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Focus.Api.Middlewares;
using Focus.Application;
using Focus.Infrastructure.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Module")]
    public class ModuleController : FocusControllerBase
    {
        private readonly ModuleAppService _moduleAppService;
        public ModuleController()
        {
            _moduleAppService = IoCConfig.Get<ModuleAppService>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await ExecuteAsync(async () => await (_moduleAppService.GetAllAsync()));
            return Ok(result);
        }
    }
}