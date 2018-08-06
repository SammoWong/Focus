using System;
using System.Threading.Tasks;
using Focus.Auth.Models;
using Focus.Infrastructure;
using Focus.Infrastructure.Web.Common;
using Focus.Service.Interfaces;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Auth.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        public AccountController(IIdentityServerInteractionService interaction)
        {
            _interaction = interaction;
        }

        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [Route("api/[controller]/Login")]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            if (ModelState.IsValid)
            {
                var userService = Ioc.Get<IUserService>();
                var result = await userService.LoginAsync(model.Account, model.Password);
                var user = result.Item2;
                if (user != null)
                {
                    AuthenticationProperties props = null;
                    if (model.RememberMe)
                    {
                        props = new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(30))
                        };
                    }
                    await HttpContext.SignInAsync(user.Id, user.Account, props);
                    if (_interaction.IsValidReturnUrl(model.ReturnUrl) || Url.IsLocalUrl(model.ReturnUrl))
                    {
                        //return Redirect(model.ReturnUrl);
                        return Ok(new StandardResult().Succeed(result.Item1, model.ReturnUrl));
                    }
                    //return Redirect("~/");
                    return Ok(new StandardResult().Succeed(result.Item1, "~/"));
                }
                return Json(new StandardResult().Fail(StandardCode.InternalError, result.Item1));
            }
            return Json(new StandardResult().Fail(StandardCode.ArgumentError, "参数有误"));
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