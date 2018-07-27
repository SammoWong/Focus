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
        public async Task<IActionResult> GetDictionaryTypesAsync()
        {
            var dictionaryService = Ioc.Get<IDictionaryService>();
            var dictionaryTypes = await dictionaryService.GetDictionaryTypesAsync();
            return Ok(new StandardResult().Succeed(null, dictionaryTypes));
        }
    }
}