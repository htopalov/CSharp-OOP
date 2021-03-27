using System;

namespace Template_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            WhiteBread whiteBread = new WhiteBread();
            whiteBread.Make();

            WholegrainBread wholegrainBread = new WholegrainBread();
            wholegrainBread.Make();

            BananaBread bananaBrewad = new BananaBread();
            bananaBrewad.Make();
        }
    }
}
