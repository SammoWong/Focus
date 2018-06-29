using Focus.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UtilityController : Controller
    {
        [HttpGet]
        [Route("VerificationCode")]
        public IActionResult VerificationCode()
        {
            return File(new VerificationCode().Create(), @"image/Gif");
        }
    }
}