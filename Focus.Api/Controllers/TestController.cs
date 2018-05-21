using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Focus.Repository.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Test")]
    public class TestController : Controller
    {
        private readonly FocusDbContext _focusDbContext;

        public TestController(FocusDbContext focusDbContext)
        {
            _focusDbContext = focusDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}