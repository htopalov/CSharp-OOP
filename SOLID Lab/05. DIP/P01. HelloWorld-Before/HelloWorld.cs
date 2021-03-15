using P01._HelloWorld_Before;
using System;

namespace P01._HelloWorld
{
    public class HelloWorld
    {
        public string Greeting(DateTime time , string name)
        {
            if (time.Hour < 12)
            {
                return "Good morning, " + name;
            }

            if (time.Hour < 18)
            {
                return "Good afternoon, " + name;
            }

            return "Good evening, " + name;
        }
    }
}
