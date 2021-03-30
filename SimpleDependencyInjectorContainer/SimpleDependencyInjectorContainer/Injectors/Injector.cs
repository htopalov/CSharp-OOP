using SimpleDependencyInjectorContainer.Attributes;
using SimpleDependencyInjectorContainer.Modules;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SimpleDependencyInjectorContainer.Injectors
{
    public class Injector
    {
        private IModule module;
        public Injector(IModule module)
        {
            this.module = module;
        }

        public TClass Inject<TClass>()
        {
            Type classType = typeof(TClass);
            ConstructorInfo[] constructors = classType.GetConstructors();
            foreach (var constructor in constructors)
            {
                if (constructor.GetCustomAttribute(typeof(Inject)) == null)
                {
                    continue;
                }
                ParameterInfo[] constructorParams = constructor.GetParameters();
                object[] implementationParams = new object[constructorParams.Length];
                int i = 0;
                foreach (var parameter in constructorParams)
                {
                    Named namedAttribute = parameter.GetCustomAttribute(typeof(Named)) as Named;
                    Type implementationType = module.GetMapping(parameter.ParameterType, namedAttribute);
                    if (implementationType == null)
                    {
                        implementationParams[i++] = null;
                    }
                    else
                    {
                        implementationParams[i++] = Activator.CreateInstance(implementationType);
                    }
                }
                return (TClass)Activator.CreateInstance(classType, implementationParams);
            }
            return default(TClass);
        }
    }
}
