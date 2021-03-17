using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in allTypes)
            {
                if (!type.GetCustomAttributes().Any(a=>a.GetType() == typeof(AuthorAttribute)))
                {
                    continue;
                }

                AuthorAttribute[] attributes = type.GetCustomAttributes()
                    .Where(t => t.GetType() == typeof(AuthorAttribute))
                    .Select(t => (AuthorAttribute)t)
                    .ToArray();
                foreach (var attribute in attributes)
                {
                    Console.WriteLine($"{type.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}
