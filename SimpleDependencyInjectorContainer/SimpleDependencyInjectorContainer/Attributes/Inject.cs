using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDependencyInjectorContainer.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false)]
    public class Inject : Attribute
    {
    }
}
