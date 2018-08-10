using System.Threading.Tasks;
using Focus.Infrastructure;
using Focus.Infrastructure.Web.Common;
using Focus.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    [ApiController]
    public class ModuleController : FocusApiControllerBase
    {
        [HttpGet]
        [Route("api/Module")]
        public async Task<IActionResult> GetAllAsync()
        {
            var moduleService = Ioc.Get<IModuleService>();
            var modules = await moduleService.GetAllAsync();
            return Ok(new StandardResult().Succeed(null, modules));
        }

        [HttpGet]
        [Route("api/Modules/Tree")]
        public async Task<IActionResult> GetTreeAsync()
        {
            var moduleService = Ioc.Get<IModuleService>();
            var result = await moduleService.GetTreeAsync();
            return Ok(new StandardResult().Succeed(null, result));
        }

        [HttpGet]
        [Route("api/Modules/{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var moduleService = Ioc.Get<IModuleService>();
            var result = await moduleService.GetByIdAsync(id);
            return Ok(new StandardResult().Succeed(null, result));
        }
    }
}