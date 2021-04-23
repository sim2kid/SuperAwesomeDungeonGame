using System;
using System.Collections.Generic;
using System.Numerics;

namespace SuperAwesomeDungeonGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> milestones = new List<string>();
            milestones.Add("Combat Loop Test");
            milestones.Add("Exploration Loop Test");
            IO.Out("Hello! Welcome to SuperAwesomeDungeonGame! Here are the compleated parts so far! Please select one to play!");
            int doThis = IO.MakeChoice(milestones);
            switch (doThis) 
            {
                case 0:
                    combatLoopTest();
                    break;
                case 1:
                    explorationLoopTest();
                    break;
                default:
                    IO.Out("That's all!");
                    break;
            }
        }

        static void testDoors() 
        {
            IO.Out(Util.DiscernDirection(1, Direction.North));
            IO.Out(Util.DiscernDirection(1, Direction.South));

            while (true)
            {
                foreach (string here in IO.ListenCommands("I'm Listening!", "> "))
                    IO.Out(here + ".");
            }
        }

        static Room[] gimmieSomeRooms() 
        {
            Room[] rooms = new Room[9];
            rooms[0] = new Room(
                new Vector2(0, 0),
                "Front Room",
                "You stand in a tall dusty room. A chandelier hangs from the ceiling. An opening stems to the north revealing another room. A dusty wooden door blocks your way to the east.",
                0b0011);
            rooms[1] = new Room(
                new Vector2(1,0),
                "The Study",
                "You enter a dusty room with rustic wooden walls. In the center of the room is an old desk with a typewriter on it. There's a wooden door to the west and a wooden door to the east.",
                0b1010);
            rooms[2] = new Room(
                new Vector2(2, 0),
                "Wash Room",
                "You stand in the bathroom. There's an old toilet, a run down sink, and a small trash bin. There's a wooden door to the west and to the north.",
                0b1001);
            rooms[3] = new Room(
                new Vector2(0, 1),
                "Living Room",
                "You stand in a room with a couch on the north wall. A sign hangs above it that reads \"No Dead Allowd\". Must be the Living Room. There is an opening to the south and an opening to the east.",
                0b0110);
            rooms[4] = new Room(
                new Vector2(1,1),
                "Dining Room",
                "A large table sits at the center of the room with 6 chairs pulled up to it. A fancy light fixture hangs over the table. A nice china cabinet sits on the south wall. There is a walk way to the west and to the north.",
                0b1001);
            rooms[5] = new Room(
                new Vector2(1, 2),
                "Rec Room",
                "A room with a couch to the east and a huge TV to the west. Odd stark contrast in technology, but there's a wooden door to the sourth and a walkway to the north.",
                0b0101);
            rooms[6] = new Room(
                new Vector2(0, 2),
                "Bedroom",
                "A bed sits in the back of the room on the east side. A rustic wooden dresser sits on the north side and a wooden display shelf shows off a collection of Russian nesting dolls from all eras. There is a stairwell on the west side of the room.",
                0b1000);
            rooms[7] = new Room(
                new Vector2(1, 2),
                "Kitchen",
                "An 80s style fridge sits on the west side of the room with a sink in the north west corner. A stove is nessled in the counter on the north end of the room. There's a walkway to the east and the south of the room.",
                0b0110);
            rooms[8] = new Room(
                new Vector2(2,2),
                "Hallway",
                "A hallway with torn paper walls connects to the south and the west. A stairwell leads to the east.",
                0b1110);
            return rooms;
        }

        static void explorationLoopTest() 
        {
            Exploration epLoop = new Exploration(3, new Vector2(0, 0));
            foreach (Room room in gimmieSomeRooms()) 
            {
                epLoop.AssignRoom(room);
            }
            Player player = getAPlayer();
            epLoop.RunLoop(player);
        }

        static Player getAPlayer() 
        {
            Weapon sword = new Weapon("Kami Katana", false);
            Attack slash = new Attack("Slash", 10);
            Attack pierce = new Attack("Pierce", 8);
            sword.AddAttack(slash);
            sword.AddAttack(pierce);

            Weapon bomba = new Weapon("Terrorist Bomb Vest", true);
            bomba.Amount = 500;
            Attack blowUp = new Attack("Blow Up Buildings", 20);
            bomba.AddAttack(blowUp);


            Treat cookie = new Treat("Cookies", true, 8);
            cookie.Amount = 5;

            Player player = new Player("Rocky The Knight", 60);
            player.Inventory.AddItem(cookie);
            player.Inventory.AddItem(sword);
            player.Inventory.AddItem(bomba);

            return player;
        }

        static void combatLoopTest() 
        {
            Player player = getAPlayer();

            Weapon fist = new Weapon("Ogre Fist", false);
            Attack slam = new Attack("Slam", 5);
            Attack punch = new Attack("Punch", 6);
            fist.AddAttack(slam);
            fist.AddAttack(punch);

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
