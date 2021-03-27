using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            SandwichMenu menu = new SandwichMenu();
            menu["Small"] = new Sandwich("White bread", "Pork", "Cheese", "Cabage");
            menu["Medium"] = new Sandwich("Wholegrain", "Chicken", "Smoked cheese", "Peppers");
            menu["Large"] = new Sandwich("Italian bread", "Fish", "NO cheese", "Tommatoes");

            menu["Vegeterian"] = new Sandwich("Baked bread", " No meat", "No chees", "Potatoes");


            Sandwich sandwich1 = menu["Small"].Clone() as Sandwich;
            Sandwich sandwich2 = menu["Large"].Clone() as Sandwich;
            Sandwich sandwich3 = menu["Vegeterian"].Clone() as Sandwich;
        }
    }
}
