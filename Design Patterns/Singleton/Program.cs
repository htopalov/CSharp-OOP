using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("Kazanlak"));
            var db2 = SingletonDataContainer.Instance;
            Console.WriteLine(db2.GetPopulation("Sofia"));
            var db3 = SingletonDataContainer.Instance;
            Console.WriteLine(db3.GetPopulation("Plovdiv"));
        }
    }
}
