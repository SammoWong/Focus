using System.Threading.Tasks;
using Focus.Domain.Services;
using Focus.Infrastructure;
using Focus.Infrastructure.Web.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ModuleController : ControllerBase
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