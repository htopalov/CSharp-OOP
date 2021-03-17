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

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            Type classType = Type.GetType(className);
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");
            MethodInfo[] methods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var method in methods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            MethodInfo[] methods = classType.GetMethods(BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.Public)
                .Where(x => x.Name.StartsWith("get") || x.Name.StartsWith("set"))
                .ToArray();
            foreach (var method in methods)
            {
                if (method.Name.StartsWith("get"))
                {
                    sb.AppendLine($"{method.Name} will return {method.ReturnType}");
                }
            }
            foreach (var method in methods)
            {
                if (method.Name.StartsWith("set"))
                {
                    sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
