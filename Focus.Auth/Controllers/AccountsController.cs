using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Auth.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Login(string returnUrl)
        {
            return View();
        }
    }
}