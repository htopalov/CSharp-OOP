using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string resultFields = spy.StealFieldInfo("Stealer.Hacker", new string[] { "username", "password" });
            Console.WriteLine(resultFields);

            string resultModifiers = spy.AnalyzeAccessModifiers("Hacker");
            Console.WriteLine(resultModifiers);
        }
    }
}
