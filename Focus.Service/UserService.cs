using Focus.Domain.Entities;
using Focus.Domain.Services;
using Focus.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Focus.Service
{
    public class UserService : FocusServiceBase, IUserService
    {
        public async Task AddAsync(User user)
        {
            using(var db = base.NewDbContext())
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Tuple<string, User>> LoginAsync(string account, string password)
        {
            var user = new User();
            using(var db = NewDbContext())
            {
                user = await db.Users.FirstOrDefaultAsync(e => e.Account == account);
            }
            if(user == null)
                return new Tuple<string, User>("账号不存在", null);

            if (!user.Enabled)
                return new Tuple<string, User>("账号未激活", null);

            var salt = user.Salt;
            password = SaltHelper.GenerateSaltedHash(password, salt);
            if (password != user.Password)
                return new Tuple<string, User>("密码不正确", null);

            return new Tuple<string, User>("登陆成功", user);
        }

        public async Task<User> GetUserById(string id)
        {
            using (var db = NewDbContext())
            {
                var user = await db.Users.Include(u => u.Role).Where(u => u.Id == id).FirstOrDefaultAsync();
                return user;
            }
        }
    }
}
