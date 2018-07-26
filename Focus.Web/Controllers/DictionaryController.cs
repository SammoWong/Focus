using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Web.Controllers
{
    [Authorize]
    public class DictionaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}