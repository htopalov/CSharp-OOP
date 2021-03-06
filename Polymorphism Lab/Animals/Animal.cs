namespace Animals
{
    public class Animal
    {

        public Animal(string name, string food)
        {
            this.Name = name;
            this.Food = food;
        }
        public string Name { get; private set; }
        public string Food { get; private set; }
        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.Food}";
        }
    }
}
