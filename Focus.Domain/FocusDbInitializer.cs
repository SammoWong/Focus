using Focus.Domain.Entities;
using Focus.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Focus.Domain
{
    public static class FocusDbInitializer
    {
        /// <summary>
        /// 添加种子数据方便测试
        /// </summary>
        /// <param name="context"></param>
        public static void SeedData()
        {
            using (var context = new FocusDbContext())
            {
                if (!context.Users.Any())//添加用户种子数据
                {
                    var salt = PasswordHelper.GenerateSalt();
                    var users = new List<User>
                    {
                        new User
                        {
                            Id = "ede7cad9-692c-4563-9adb-7eb2a37048a9",
                            Account = "admin",
                            Salt = salt,
                            Password = PasswordHelper.ComputeHash("123456", salt),
                            RoleId = "938858c1-e722-4360-a645-7ace8b1cf683",
                            CreatedTime = DateTime.Now,
                            Enabled = true,
                            IsDeleted = false,
                            CompanyId = "b735380d-e292-4bf4-b735-1286b165d5e1",
                        },
                        new User
                        {
                            Id = "962fa3fe-d29a-4bc6-b137-62aa90d713e2",
                            Account = "system",
                            Salt = salt,
                            Password = PasswordHelper.ComputeHash("123456", salt),
                            RoleId = "d3390e64-0ea4-47dc-9159-07c16ca905aa",
                            CreatedTime = DateTime.Now,
                            Enabled = true,
                            IsDeleted = false,
                            CompanyId = "b735380d-e292-4bf4-b735-1286b165d5e1"
                        },
                    };
                    context.Users.AddRange(users);
                }
                if (!context.Roles.Any())//添加角色种子数据
                {
                    var roles = new List<Role>()
                    {
                        new Role
                        {
                            Id = "938858c1-e722-4360-a645-7ace8b1cf683",
                            Code = "system",
                            Name = "系统管理员",
                            CreatedTime = DateTime.Now,
                            Enabled = true,
                            CreatedBy = "ede7cad9-692c-4563-9adb-7eb2a37048a9",
                            IsDeleted = false,
                            CompanyId = "b735380d-e292-4bf4-b735-1286b165d5e1"
                        },
                        new Role
                        {
                            Id = "d3390e64-0ea4-47dc-9159-07c16ca905aa",
                            Code = "administrator",
                            Name = "超级管理员",
                            CreatedTime = DateTime.Now,
                            Enabled = true,
                            CreatedBy = "ede7cad9-692c-4563-9adb-7eb2a37048a9",
                            IsDeleted = false,
                            CompanyId = "b735380d-e292-4bf4-b735-1286b165d5e1"
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
                        },
                        new Module
                        {
                            Id = "ad368108-4777-4672-b56d-104b6d227168",
                            ParentId = "6ae17edf-d645-43f0-b6f0-f081e27f7c4a",
                            Name = "公司管理",
                            Url = "/Company/Index",
                            Category = Domain.Enums.ModuleCategory.Page,
                            Rank = 2,
                            SortNumber = 3,
                            IsExpanded = false,
                            IsDeleted = false,
                            CreatedTime = DateTime.Now,
                            Enabled = true
                        }
                    };
                    context.Modules.AddRange(modules);
                }
                if (!context.DictionaryTypes.Any())
                {
                    var dictionaryTypes = new List<DictionaryType>
                    {
                        new DictionaryType
                        {
                            Id = "3fa89a89-9a5f-4dc6-886d-edc6b9d074ee",
                            ParentId = string.Empty,
                            Name = "通用数据字典",
                            SortNumber = 1,
                            Enabled = true,
                            CreatedTime = DateTime.Now,
                            IsDeleted = false
                        },
                        new DictionaryType
                        {
                            Id = "0435ebf6-71a8-466b-a7a5-fada1638eaca",
                            ParentId = "3fa89a89-9a5f-4dc6-886d-edc6b9d074ee",
                            Name = "婚姻",
                            SortNumber = 2,
                            Enabled = true,
                            CreatedTime = DateTime.Now,
                            IsDeleted = false
                        },
                        new DictionaryType
                        {
                            Id = "8f54f12f-3154-4312-8595-4e5f341c0387",
                            ParentId = "3fa89a89-9a5f-4dc6-886d-edc6b9d074ee",
                            Name = "学历",
                            SortNumber = 3,
                            Enabled = true,
                            CreatedTime = DateTime.Now,
                            IsDeleted = false
                        }
                    };
                    context.DictionaryTypes.AddRange(dictionaryTypes);
                }
                if (!context.DictionaryDetails.Any())
                {
                    var dictionaryDetails = new List<DictionaryDetail>()
                    {
                        new DictionaryDetail
                        {
                            TypeId = "0435ebf6-71a8-466b-a7a5-fada1638eaca",
                            Id = "2d861175-8632-410a-80f2-a8f634ced7a7",
                            Name = "未婚",
                            SortNumber = 1,
                            Enabled = true,
                            CreatedTime = DateTime.Now,
                            IsDeleted = false
                        },
                        new DictionaryDetail
                        {
                            TypeId = "0435ebf6-71a8-466b-a7a5-fada1638eaca",
                            Id = "def9ecc7-d7cd-4a84-be40-efcfdd44cba4",
                            Name = "已婚",
                            SortNumber = 2,
                            Enabled = true,
                            CreatedTime = DateTime.Now,
                            IsDeleted = false
                        },
                        new DictionaryDetail
                        {
                            TypeId = "0435ebf6-71a8-466b-a7a5-fada1638eaca",
                            Id = "672a39d8-954b-499c-8b37-d8d03ad966c0",
                            Name = "离异",
                            SortNumber = 3,
                            Enabled = true,
                            CreatedTime = DateTime.Now,
                            IsDeleted = false
                        },
                        new DictionaryDetail
                        {
                            TypeId = "0435ebf6-71a8-466b-a7a5-fada1638eaca",
                            Id = "e9776b4e-ac6e-4c2a-a3e6-9b56cbce7f6d",
                            Name = "丧偶",
                            SortNumber = 4,
                            Enabled = true,
                            CreatedTime = DateTime.Now,
                            IsDeleted = false
                        },
                        new DictionaryDetail
                        {
                            TypeId = "0435ebf6-71a8-466b-a7a5-fada1638eaca",
                            Id = "82bccc1a-2f50-40c9-9f14-945d148e1e16",
                            Name = "其他",
                            SortNumber = 5,
                            Enabled = true,
                            CreatedTime = DateTime.Now,
                            IsDeleted = false
                        }
                    };
                    context.DictionaryDetails.AddRange(dictionaryDetails);
                }
                if (!context.Companies.Any())
                {
                    var company = new Company
                    {
                        Id = "b735380d-e292-4bf4-b735-1286b165d5e1",
                        FullName = "Focus集团",
                        ShortName = "Focus Group",
                        Nature = string.Empty,
                        Website = "https://cn.bing.com/",
                        Email = "123456@abc.com",
                        Creator = "focus",
                        Contact = "focus",
                        Phone = "123456789",
                        Address = "中国广东深圳",
                        Enabled = true,
                        CreatedBy = "ede7cad9-692c-4563-9adb-7eb2a37048a9",
                        CreatedTime = DateTime.Now,
                        IsDeleted = false
                    };
                    context.Companies.Add(company);
                }
                context.SaveChanges();
            }
        }
    }
}
