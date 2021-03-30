using SimpleDependencyInjectorContainer.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDependencyInjectorContainer.Modules
{
    public interface IModule
    {
        void Configure();

        Type GetMapping(Type type, Named namedAttribute = null);

        void CreateMapping<TInterface, TImplementation>();
    }
}
