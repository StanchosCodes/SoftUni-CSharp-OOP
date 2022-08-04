using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DarkKnight dk = new DarkKnight("Dark Knight", 250);
            DarkWizard dw = new DarkWizard("Dark Wizard", 300);
            SoulMaster sm = new SoulMaster("Soul Master", 350);
            BladeKnight bk = new BladeKnight("Blade Knight", 400);
            MuseElf me = new MuseElf("Muse Elf", 450);
            Elf e = new Elf("Elf", 500);
            Wizard w = new Wizard("Wizard", 550);
            Knight k = new Knight("Knight", 600);

            Console.WriteLine(dk);
            Console.WriteLine(dw);
            Console.WriteLine(sm);
            Console.WriteLine(bk);
            Console.WriteLine(me);
            Console.WriteLine(e);
            Console.WriteLine(w);
            Console.WriteLine(k);
        }
    }
}