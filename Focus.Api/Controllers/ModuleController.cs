using System.Threading.Tasks;
using Focus.Infrastructure;
using Focus.Infrastructure.Web.Common;
using Focus.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : FocusApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var moduleService = Ioc.Get<IModuleService>();
            var modules = await moduleService.GetAllAsync();
            return Ok(new StandardResult().Succeed(null, modules));
        }
    }
}