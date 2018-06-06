﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Focus.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        [HttpGet]
        [Route("VerificationCode")]
        public IActionResult VerificationCode()
        {
            return File(new VerificationCode().Create(), @"image/Gif");
        }
    }
}