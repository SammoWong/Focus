using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Focus.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Auth.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        [Route("api/[controller]/VerificationCode")]
        public IActionResult VerificationCode()
        {
            var codeGenerator = new VerificationCode();
            var code = codeGenerator.GenerateCode();
            return File(codeGenerator.CreateCode(code), @"image/Gif");
        }
    }
}