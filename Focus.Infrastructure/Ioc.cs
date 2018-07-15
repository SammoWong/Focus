using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Focus.Infrastructure
{
    public class Ioc
    {
        private static IContainer _container;
        private static ContainerBuilder _builder = new ContainerBuilder();

        public static IContainer GetContainer()
        {
            _container = _builder.Build();
            return _container;
        }

        public static void RegisterAssemblyTypes(Assembly assembly)
        {
            _builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().SingleInstance();
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
