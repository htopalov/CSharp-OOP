using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, string[] fieldNames)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            sb.AppendLine($"Class under investigation: {classType.FullName}");
            FieldInfo[] fields = classType.GetFields(BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.NonPublic)
                .Where(x => fieldNames.Contains(x.Name))
                .ToArray();

            Object instance = Activator.CreateInstance(classType, new object[] { });

            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }

            return sb.ToString().Trim();
        }
        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);
            FieldInfo[] fields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Public |
                                         BindingFlags.Instance)
                                         .Where(n => n.Name.StartsWith("set"))
                                         .ToArray();

            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.NonPublic)
                                          .Where(n => n.Name.StartsWith("get"))
                                          .ToArray();
            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var method in publicMethods)
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
     
            foreach (var method in privateMethods)
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            return sb.ToString().Trim();
        }
    }
}
