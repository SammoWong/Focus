using Focus.Domain.Entities;
using Focus.Infrastructure.Security;
using Focus.Repository.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Focus.Api.Middlewares
{
    public static class FocusDbContextExtensions
    {
        /// <summary>
        /// 添加种子数据方便测试
        /// </summary>
        /// <param name="context"></param>
        public static void EnsureSeedDataForContext(this FocusDbContext context)
        {
            if (!context.Users.Any())
            {
                var user = new User
                {
                    Id = "ede7cad9-692c-4563-9adb-7eb2a37048a9",
                    Account = "admin",
                    Salt = SaltHelper.CreateSalt(24),
                    Password = SaltHelper.GenerateSaltedHash("123456", SaltHelper.CreateSalt(24)),
                    RoleId = "938858c1-e722-4360-a645-7ace8b1cf683",
                    CreatedTime = DateTime.Now
                };
                context.Users.Add(user);
            }
            if (!context.Roles.Any())
            {
                var roles = new List<Role>()
                {
                    new Role
                    {
                        Id = "938858c1-e722-4360-a645-7ace8b1cf683",
                        Name = "管理员",
                        CreatedTime = DateTime.Now
                    },
                    new Role
                    {
                        Id = "d3390e64-0ea4-47dc-9159-07c16ca905aa",
                        Name = "超级管理员",
                        CreatedTime = DateTime.Now
                    }
                };
                context.Roles.AddRange(roles);
            }
            context.SaveChanges();
        }
    }
}
