using Focus.Domain.Entities;
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
            if (!context.Role.Any())
            {
                var roles = new List<Role>()
                {
                    new Role
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "管理员",
                        CreatedTime = DateTime.Now
                    },
                    new Role
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "超级管理员",
                        CreatedTime = DateTime.Now
                    }
                };
                context.Role.AddRange(roles);
                context.SaveChanges();
            }
        }
    }
}
