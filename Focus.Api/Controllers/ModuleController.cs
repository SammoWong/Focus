using System.Threading.Tasks;
using Focus.Domain.Services;
using Focus.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var moduleService = Ioc.Get<IModuleService>();
            var modules = await moduleService.GetAllAsync();
            return Ok(modules);
        }
    }
}