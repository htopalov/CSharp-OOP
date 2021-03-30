﻿using SimpleDependencyInjectorContainer.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleDependencyInjectorContainer.Modules
{
    public abstract class AbstractModule : IModule
    {
        private IDictionary<Type, List<Type>> mappings;
        public AbstractModule()
        {
            mappings = new Dictionary<Type, List<Type>>();
            Configure();
        }
        public abstract void Configure();

        public void CreateMapping<TInterface, TImplementation>()
        {
            if (!mappings.ContainsKey(typeof(TInterface)))
            {
                mappings.Add(typeof(TInterface), new List<Type>());
            }
            mappings[typeof(TInterface)].Add(typeof(TImplementation));
        }

        public Type GetMapping(Type interfaceType, Named namedAttribute = null)
        {
            if (!mappings.ContainsKey(interfaceType))
            {
                return null;
            }
            if (namedAttribute == null)
            {
                return mappings[interfaceType][0];
            }
            else
            {
                return mappings[interfaceType].FirstOrDefault(m => m.Name == namedAttribute.TypeName.Name);
            }
        
        }
    }
}
