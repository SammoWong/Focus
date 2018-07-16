﻿using Focus.Domain.Services;
using Focus.Infrastructure;
using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Focus.Auth
{
    public class ProfileService : IProfileService
    {
        private readonly IUserService _userService;

        public ProfileService()
        {
            _userService = new Service.UserService();
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = _userService.GetUserById(context.Subject.GetSubjectId()).Result;
            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Subject, context.Subject.GetSubjectId()),
                new Claim(JwtClaimTypes.Email, user.Email ?? string.Empty),
                new Claim("userName", user.Account),
                new Claim("account", user.Account),
                new Claim(JwtClaimTypes.Role, user.Role.Name)
            };
            context.IssuedClaims.AddRange(claims);
            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            string id = context.Subject.GetSubjectId();
            var user = _userService.GetUserById(context.Subject.GetSubjectId()).Result;
            if (user != null)
            {
                context.IsActive = true;
            }
            else
            {
                context.IsActive = false; // check with identiy user;
            }
            return Task.FromResult(0);
        }
    }
}
