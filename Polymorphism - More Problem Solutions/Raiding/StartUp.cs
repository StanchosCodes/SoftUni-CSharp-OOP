using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                if (type == "Druid")
                {
                    BaseHero newHero = new Druid(name);
                    heroes.Add(newHero);
                }
                else if (type == "Paladin")
                {
                    BaseHero newHero = new Paladin(name);
                    heroes.Add(newHero);
                }
                else if (type == "Rogue")
                {
                    BaseHero newHero = new Rogue(name);
                    heroes.Add(newHero);
                }
                else if (type == "Warrior")
                {
                    BaseHero newHero = new Warrior(name);
                    heroes.Add(newHero);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            int totalPowerAmount = heroes.Sum(h => h.Power);

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            if (totalPowerAmount >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
