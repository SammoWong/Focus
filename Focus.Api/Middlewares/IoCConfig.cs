using Autofac;
using Focus.Application;
using Focus.Domain;
using Focus.Domain.Repositories;
using Focus.Domain.Services;
using Focus.Repository.EntityFrameworkCore;
using Focus.Repository.EntityFrameworkCore.Repositories;
using Focus.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Focus.Api.Middlewares
{
    public class IoCConfig
    {
        private static IContainer _container;

        public static IContainer Register(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType(typeof(FocusDbContext)).As(typeof(FocusDbContext)).InstancePerLifetimeScope();
            //注册数据库基础操作和工作单元
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>));

            //注册ApplicationService
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(RoleAppService)));

            //注册领域服务
            builder.RegisterAssemblyTypes(typeof(RoleService).Assembly)
                .Where(a => a.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .SingleInstance();

            //注册领域服务
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                .Where(a => a.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .SingleInstance();

            _container = builder.Build();
            return _container;
        }

        /// <summary>
        /// 从容器中获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
