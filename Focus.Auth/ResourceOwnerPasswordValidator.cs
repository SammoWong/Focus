using Focus.Domain.Services;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Focus.Auth
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserService _userService;
        public ResourceOwnerPasswordValidator(IUserService userService)
        {
            _userService = userService;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var loginResult = _userService.LoginAsync(context.UserName, context.Password).Result;
            var user = loginResult.Item2;
            if (user != null)
            {
                context.Result = new GrantValidationResult(loginResult.Item1, "password", null, "local", null);
                return Task.FromResult(context.Result);
            }
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, loginResult.Item1, null);
            return Task.FromResult(context.Result);
        }
    }
}
