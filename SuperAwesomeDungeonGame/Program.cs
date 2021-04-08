using System;
using System.Collections.Generic;

namespace SuperAwesomeDungeonGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Weapon sword = new Weapon("Kami Katana", false);
            Attack slash = new Attack("Slash", 10);
            Attack pierce = new Attack("Pierce", 8);
            sword.AddAttack(slash);
            sword.AddAttack(pierce);

            Weapon fist = new Weapon("Ogre Fist", false);
            Attack slam = new Attack("Slam", 5);
            Attack punch = new Attack("Punch", 6);
            fist.AddAttack(slam);
            fist.AddAttack(punch);

            Treat cookie = new Treat("Cookies", true, 8);
            cookie.Amount = 5;

            Player player = new Player("Rocky The Knight", 60);
            player.Inventory.AddItem(cookie);
            player.Inventory.AddItem(sword);

            Monster ogre = new Monster("Ogre", 80);
            ogre.Weapon = fist;

            List<Creature> players = new List<Creature>();
            List<Creature> monsters = new List<Creature>();

            players.Add(player);
            monsters.Add(ogre);

            Combat c = new Combat(players, monsters);

            List<string> choices = new List<string>();
            choices.Add("Yes I Did!");
            choices.Add("No I Didn't.");
            IO.Out("Did you like the combat loop?");
            if (IO.MakeChoice(choices, "? ") == 1) 
            {
                IO.Out("Well maybe you should try making it then, punk!");
            }
            else 
            {
                IO.Out("Sweet! Well see ya later!");
            }
        }
    }
}
