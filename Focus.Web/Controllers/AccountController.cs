using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Web.Controllers
{
    public class AccountController : Controller
    {
        //TODO:登陆页面，目前放Auth项目里
        public IActionResult Login()
        {
            return View();
        }
        //TODO:callback->HomeController
        public IActionResult Callback()
        {
            return View();
        }
    }
}