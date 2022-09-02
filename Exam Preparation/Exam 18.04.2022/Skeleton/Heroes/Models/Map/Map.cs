namespace Heroes.Models.Map
{
    using System.Linq;
    using System.Collections.Generic;

    using Heroes;
    using Contracts;

    public class Map : IMap
    {
        public string Fight(ICollection<IHero> heros)
        {
            List<Knight> knights = new List<Knight>();
            List<Barbarian> barbarians = new List<Barbarian>();

            foreach (IHero hero in heros)
            {
                if (hero.GetType() == typeof(Knight) && hero.IsAlive)
                {
                    knights.Add(hero as Knight);
                }
                else
                {
                    barbarians.Add(hero as Barbarian);
                }
            }

            while (knights.Any(k => k.IsAlive) && barbarians.Any(b => b.IsAlive))
            {
                foreach (Knight knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        foreach (Barbarian barbarian in barbarians.Where(b => b.IsAlive))
                        {
                            barbarian.TakeDamage(knight.Weapon.DoDamage());
                        }
                    }
                }

                foreach (Barbarian barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        foreach (Knight knight in knights.Where(k => k.IsAlive))
                        {
                            knight.TakeDamage(barbarian.Weapon.DoDamage());
                        }
                    }
                }
            }

            int deathKnights = 0;
            int deathBarbarians = 0;

            foreach (Knight knight in knights)
            {
                if (!knight.IsAlive)
                {
                    deathKnights++;
                }
            }

            foreach (Barbarian barbarian in barbarians)
            {
                if (!barbarian.IsAlive)
                {
                    deathBarbarians++;
                }
            }

            if (knights.Any(k => k.IsAlive))
            {
                return $"The knights took {deathKnights} casualties but won the battle.";
            }
            else
            {
                return $"The barbarians took {deathBarbarians} casualties but won the battle.";
            }
        }
    }
}
