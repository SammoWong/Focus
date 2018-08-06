using System.Threading.Tasks;
using Focus.Infrastructure;
using Focus.Infrastructure.Web.Common;
using Focus.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    public class RoleController : FocusApiControllerBase
    {
        [HttpGet]
        [Route("api/Roles")]
        public async Task<IActionResult> GetAllAsync()
        {
            var service = Ioc.Get<IRoleService>();
            var roles = await service.GetAllAsync();
            return Ok(new StandardResult().Succeed(null, roles));
        }
    }
}