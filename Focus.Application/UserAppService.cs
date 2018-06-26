using Focus.Domain.Entities;
using Focus.Domain.Services;
using Focus.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Application
{
    public class UserAppService
    {
        private readonly IUserService _userService;
        public UserAppService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Tuple<string, User>> LoginAsync(string account, string password)
        {
            return await _userService.LoginAsync(account, password);
        }
    }
}
