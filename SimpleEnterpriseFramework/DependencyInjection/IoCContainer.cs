using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleEnterpriseFramework.DependencyInjection
{
    public class IoCContainer
    {
        private static readonly Dictionary<Type, object> RegisteredDependencies = new Dictionary<Type, object>();

        public static void Register<TInterface, TModule>()
        {
            if (!typeof(TInterface).IsAssignableFrom(typeof(TModule)))
            {
                throw new ArgumentException($"Dependency: {typeof(TModule)} không tương thích với dạng Interface: {typeof(TInterface)} được truyền!");
            }

            if (!(typeof(TInterface).IsInterface || typeof(TInterface).IsClass))
            {
                throw new ArgumentException($"{typeof(TInterface)} không phải dạng Interface hoặc Class");
            }

            if (!typeof(TModule).IsClass)
            {
                throw new ArgumentException($"{typeof(TModule)} không phải dạng Class");
            }

            var constructor = typeof(TModule).GetConstructors().FirstOrDefault();

            if (constructor != null)
            {
                var constructorParameters = constructor.GetParameters();
                var moduleDependencies = constructorParameters.Select(parameter => GetDependency(parameter.ParameterType)).ToArray();
                var module = Activator.CreateInstance(typeof(TModule), moduleDependencies);
                RegisteredDependencies[typeof(TInterface)] = module;
            }
            else
            {
                var module = Activator.CreateInstance(typeof(TModule));
                RegisteredDependencies[typeof(TInterface)] = module;
            }
        }

        public static TInterface Resolve<TInterface>()
        {
            return (TInterface)GetDependency(typeof(TInterface));
        }

        private static object GetDependency(Type interfaceType)
        {
            if (RegisteredDependencies.ContainsKey(interfaceType))
            {
                return RegisteredDependencies[interfaceType];
            }
            throw new Exception($"Dependency: {interfaceType} chưa được register!");
        }
    }
}
