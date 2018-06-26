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
    [Route("api/Role")]
    public class RoleController : FocusControllerBase
    {
        private readonly RoleAppService _roleAppService;

        public RoleController()
        {
            _roleAppService = IoCConfig.Get<RoleAppService>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _roleAppService.GetAllAsync();
            //var temp = await ExecuteAsync(() => _roleAppService.GetAllAsync().Result.ToList());
            return Ok(new StandardJsonResult<List<Domain.Entities.Role>> { Data = result.ToList(), State = true });
            //return Ok(await _roleAppService.GetAllAsync());
        }
    }
}