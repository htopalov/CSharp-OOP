using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                MyValidationAttribute[] attributes = property.GetCustomAttributes().Cast<MyValidationAttribute>().ToArray();

                var value = property.GetValue(obj);
                foreach (var attr in attributes)
                {
                    if (!attr.IsValid(value))
                    {
                        return false;
                    }
                    
                }
            }
            return true;
        }
    }
}
