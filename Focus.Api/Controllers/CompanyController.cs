using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Focus.Infrastructure;
using Focus.Infrastructure.Web.Common;
using Focus.Model.Company;
using Focus.Service.Interfaces;
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

        [HttpPost]
        [Route("api/Company/Delete")]
        public async Task<IActionResult> DeleteAsync([FromForm]DeleteCompanyInputModel model)
        {
            var service = Ioc.Get<ICompanyService>();
            var company = await service.GetByIdAsync(model.Id);
            if (company == null)
                return Ok(new StandardResult().Fail(StandardCode.ArgumentError, "公司不存在"));

            company.DeletedBy = CurrentUserId;
            company.DeletedTime = DateTime.Now;
            company.IsDeleted = true;
            await service.UpdateAsync(company);
            return Ok(new StandardResult().Succeed("删除成功"));
        }
    }
}