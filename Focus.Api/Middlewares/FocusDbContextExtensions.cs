using Focus.Domain;
using Focus.Domain.Entities;
using Focus.Infrastructure;
using Focus.Service;
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
        public static void EnsureSeedDataForContext()
        {
            using (var context = new FocusDbContext())
            {
                if (!context.Users.Any())//添加用户种子数据
                {
                    var salt = PasswordHelper.GenerateSalt();
                    var user = new User
                    {
                        Id = "ede7cad9-692c-4563-9adb-7eb2a37048a9",
                        Account = "admin",
                        Salt = salt,
                        Password = PasswordHelper.ComputeHash("123456", salt),
                        RoleId = "938858c1-e722-4360-a645-7ace8b1cf683",
                        CreatedTime = DateTime.Now,
                        Enabled = true
                    };
                    context.Users.Add(user);
                }
                if (!context.Roles.Any())//添加角色种子数据
                {
                    var roles = new List<Role>()
                {
                    new Role
                    {
                        Id = "938858c1-e722-4360-a645-7ace8b1cf683",
                        Name = "管理员",
                        CreatedTime = DateTime.Now,
                        Enabled = true
                    },
                    new Role
                    {
                        Id = "d3390e64-0ea4-47dc-9159-07c16ca905aa",
                        Name = "超级管理员",
                        CreatedTime = DateTime.Now,
                        Enabled = true
                    }
                };
                    context.Roles.AddRange(roles);
                }
                if (!context.Modules.Any())//添加模块菜单种子数据
                {
                    var modules = new List<Module>()
                {
                    new Module
                    {
                        Id = "1e8b7c2d-a72f-4a1b-b3fc-30edef4fda76",
                        ParentId = string.Empty,
                        Name = "基础配置",
                        Url = string.Empty,
                        Category = Domain.Enums.ModuleCategory.Catelog,
                        Icon = "fa fa-gears",
                        Rank = 1,
                        SortNumber = 1,
                        IsExpanded = false,
                        IsDeleted = false,
                        CreatedTime = DateTime.Now,
                        Enabled = true
                    },
                    new Module
                    {
                        Id = "6ae17edf-d645-43f0-b6f0-f081e27f7c4a",
                        ParentId = string.Empty,
                        Name = "系统管理",
                        Url = string.Empty,
                        Category = Domain.Enums.ModuleCategory.Catelog,
                        Icon = "fa fa-desktop",
                        Rank = 1,
                        SortNumber = 2,
                        IsExpanded = false,
                        IsDeleted = false,
                        CreatedTime = DateTime.Now,
                        Enabled = true
                    },
                    new Module
                    {
                        Id = "1c863c82-5937-452c-b3e3-71710ac829ee",
                        ParentId = "1e8b7c2d-a72f-4a1b-b3fc-30edef4fda76",
                        Name = "数据字典",
                        Url = "/Dictionary/Index",
                        Category = Domain.Enums.ModuleCategory.Page,
                        Rank = 2,
                        SortNumber = 1,
                        IsExpanded = false,
                        IsDeleted = false,
                        CreatedTime = DateTime.Now,
                        Enabled = true
                    },
                    new Module
                    {
                        Id = "82cf950d-8d1c-40ec-a1cd-8b58a4818da0",
                        ParentId = "6ae17edf-d645-43f0-b6f0-f081e27f7c4a",
                        Name = "用户管理",
                        Url = "/User/Index",
                        Category = Domain.Enums.ModuleCategory.Page,
                        Rank = 2,
                        SortNumber = 1,
                        IsExpanded = false,
                        IsDeleted = false,
                        CreatedTime = DateTime.Now,
                        Enabled = true
                    },
                    new Module
                    {
                        Id = "530da57d-43a2-42f2-9cff-e21f766c334a",
                        ParentId = "6ae17edf-d645-43f0-b6f0-f081e27f7c4a",
                        Name = "角色管理",
                        Url = "/Role/Index",
                        Category = Domain.Enums.ModuleCategory.Page,
                        Rank = 2,
                        SortNumber = 2,
                        IsExpanded = false,
                        IsDeleted = false,
                        CreatedTime = DateTime.Now,
                        Enabled = true
                    }
                };
                    context.Modules.AddRange(modules);
                }
                context.SaveChanges();
            }

        }
    }
}
