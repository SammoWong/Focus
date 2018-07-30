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
    public class DictionaryController : ControllerBase
    {
        [Route("api/DictionaryTypes")]
        [HttpGet]
        public async Task<IActionResult> GetDictionaryTypesAsync()
        {
            var dictionaryService = Ioc.Get<IDictionaryService>();
            var dictionaryTypes = await dictionaryService.GetDictionaryTypesAsync();
            return Ok(new StandardResult().Succeed(null, dictionaryTypes));
        }

        [Route("api/DictionaryType/{typeId}/DictionaryDetails")]
        [HttpGet]
        public async Task<IActionResult> GetDictionaryDetailsByTypeIdAsync(string typeId)
        {
            var dictionaryService = Ioc.Get<IDictionaryService>();
            var dictionaryDetails = await dictionaryService.GetDictionaryDetailsByTypeIdAsync(typeId);
            return Ok(new StandardResult().Succeed(null, dictionaryDetails.ToList()));
        }
    }
}