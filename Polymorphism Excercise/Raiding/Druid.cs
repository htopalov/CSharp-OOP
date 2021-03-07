namespace Raiding
{
    public class Druid : BaseHero
    {
        private const int power = 80;
        public Druid(string name)
            : base(name)
        {
        }

        public override int Power => power;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - { Name} healed for {power}";
        }
    }
}
