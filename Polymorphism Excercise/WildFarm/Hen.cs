namespace WildFarm
{
    public class Hen : Bird
    {
        private const double foodCoefficient = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            this.Weight += food.Quantity * foodCoefficient;
            this.FoodEaten += food.Quantity;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} " + base.ToString();
        }
    }
}
