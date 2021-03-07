namespace WildFarm
{
    public class Hen : Bird
    {
        private const double foodCoefficient = 0.35;
        public Hen(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            this.Weight += food.Quantity * foodCoefficient;
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
