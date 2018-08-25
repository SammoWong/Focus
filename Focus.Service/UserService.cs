using Focus.Domain.Entities;
using Focus.Infrastructure;
using Focus.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Focus.Service
{
    public class UserService : FocusServiceBase, IUserService
    {
        public async Task<bool> IsAccountExist(string account)
        {
            using(var db = NewDbContext())
            {
                return await db.Users.AnyAsync(e => e.Account == account);
            }
        }

        public async Task AddAsync(User user)
        {
            using (var db = base.NewDbContext())
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Tuple<string, User>> LoginAsync(string account, string password)
        {
            var user = new User();
            using (var db = NewDbContext())
            {
                user = await db.Users.FirstOrDefaultAsync(e => e.Account == account);
            }
            if (user == null)
                return new Tuple<string, User>("账号不存在", null);

            if (!user.Enabled)
                return new Tuple<string, User>("账号未激活", null);

            var salt = user.Salt;
            password = PasswordHelper.ComputeHash(password, salt);
            if (password != user.Password)
                return new Tuple<string, User>("密码不正确", null);

            return new Tuple<string, User>("登陆成功", user);
        }

        public async Task<User> GetUserById(string id)
        {
            using (var db = NewDbContext())
            {
                var user = await db.Users.Include(u => u.Role).SingleOrDefaultAsync(u => u.Id == id);
                return user;
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (var db = NewDbContext())
            {
                return await db.Users.ToListAsync();
            }
        }

        public async Task UpdateAsync(User user)
        {
            using(var db = NewDbContext())
            {
                db.Users.Update(user);
                await db.SaveChangesAsync();
            }
        }
    }
}
