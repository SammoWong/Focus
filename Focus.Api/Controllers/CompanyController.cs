using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Focus.Domain.Services;
using Focus.Infrastructure;
using Focus.Infrastructure.Web.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    [ApiController]
    public class CompanyController : FocusApiControllerBase
    {
        [HttpGet]
        [Route("api/Companies")]
        public async Task<IActionResult> GetAsync()
        {
            var service = Ioc.Get<ICompanyService>();
            var companies = await service.GetCompaniesAsync();
            return Ok(new StandardResult().Succeed(null, companies));
        }
    }
}