namespace Raiding
{
    public abstract class BaseHero
    {
        private string name;
        private int power;

        public string Name { get; set; }
        public int Power { get; set; }

        protected BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public virtual string CastAbility()
        {
            return this.Name;
        }
    }
}
