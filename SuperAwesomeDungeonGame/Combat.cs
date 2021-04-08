using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAwesomeDungeonGame
{
    class Combat
    {
        public List<Creature> Players;
        public List<Creature> Monsters;
        private bool isPlayersTurn;
        private int whosTurn;

        public Combat(List<Creature> _players, List<Creature> _monsters) 
        {
            Players = _players;
            Monsters = _monsters;
            isPlayersTurn = true;
            whosTurn = 0;
            combatLoop();
        }

        private void combatLoop() 
        {
            IO.Out("A fight has started!");
            while (true) 
            {
                if (isPlayersTurn)
                { // Player's Turn
                    displayStats();
                    Player player = (Player)Players[whosTurn];
                    IO.Out("It is now " + player.Name + "'s turn.");
                    List<Weapon> weapons = new List<Weapon>();
                    List<Treat> treats = new List<Treat>();

                    foreach (Item item in player.Inventory.Items) 
                    {
                        if (item.GetType() == typeof(Weapon))
                        {
                            weapons.Add(new Weapon((Weapon)item));

                        }
                        else if (item.GetType() == typeof(Treat)) 
                        {
                            treats.Add(new Treat((Treat) item));
                        }
                    }

                    List<string> choices = new List<string>();
                    choices.Add("Attack");
                    if (treats.Count != 0)
                        choices.Add("Eat Treat");
                    IO.Out("What would you like to do?");
                    int playerChoice = IO.MakeChoice(choices, "> ");
                    switch (playerChoice) 
                    {
                        case 0:
                            // Attack
                            Attack attack = chooseAttack(chooseWeapon(weapons));
                            Monster mon = (Monster)attackWho(Monsters);

                            mon.Health -= attack.Damage;
                            IO.Out(player.Name + " has delt " + attack.Damage + " damage to " + mon.Name + "!");
                            if (mon.Health <= 0) 
                            {
                                IO.Out(player.Name + " has killed " + mon.Name + "!");
                                Monsters.Remove(mon);
                            }
                            break;
                        case 1:
                            //Eat Treat
                            Treat treat = chooseTreat(treats);
                            IO.Out(player.Name + " has consumed a " + treat.Name + " and has healed " + treat.HealthUp + " HP!");
                            player.Heal(treat.HealthUp);
                            IO.Out(player.Name + " now has (" + player.Health + "/" + player.MaxHealth + " HP)");

                            treat = new Treat(treat);
                            treat.Amount = 1;

                            player.Inventory.RemoveItem(treat);

                            break;
                    }
                    IO.Out("\n");
                }
                else 
                { // Monster's Turn
                    Monster monster = (Monster)Monsters[whosTurn];
                    IO.Out(monster.Name + " is attacking!");

                    Player toAttck = (Player)Players[monsterInput(0, Players.Count - 1)];
                    IO.Out(monster.Name + " attacks " + toAttck.Name + "!");

                    Attack attack = monster.Weapon.Attacks[monsterInput(0, monster.Weapon.Attacks.Count - 1)];
                    IO.Out($"{monster.Name} takes hold of its {monster.Weapon.Name} and uses {attack.Name} against {toAttck.Name}!");

                    toAttck.Health -= attack.Damage;
                    IO.Out($"As a result, {toAttck.Name} looses {attack.Damage} health!");
                    if (toAttck.Health <= 0) 
                    {
                        IO.Out($"{monster.Name} has successfully slain {toAttck.Name}!");
                        Players.Remove(toAttck);
                    }
                    IO.Out("\n");
                }
                whosTurn++;
                if ((Players.Count >= whosTurn && isPlayersTurn) || (Monsters.Count >= whosTurn && !isPlayersTurn)) 
                {
                    whosTurn = 0;
                    isPlayersTurn = !isPlayersTurn;
                }
                if (Players.Count <= 0 || Monsters.Count <= 0) 
                {
                    //Quit
                    break;
                }
            }
            IO.Out("The fight has ended!");
        }

        private Treat chooseTreat(List<Treat> treats) 
        {
            List<string> c = new List<string>();
            foreach (Treat treat in treats) 
            {
                c.Add(treat.Name + " (" + treat.HealthUp + ")");
            }
            IO.Out("Choose a Treat:");
            int choice = IO.MakeChoice(c, "🍪> ");
            return treats[choice];
        }

        private Creature attackWho(List<Creature> creatures) 
        {
            List<string> c = new List<string>();
            foreach (Creature creature in creatures) 
            {
                c.Add(creature.Name + " (" + creature.Health + " / " + creature.MaxHealth + " HP)");
            }
            IO.Out("Choose a Target:");
            int choice = IO.MakeChoice(c, "👹> ");
            return creatures[choice];
        }

        private Weapon chooseWeapon(List<Weapon> weapons) 
        {
            List<string> choices = new List<string>();
            foreach (Weapon weapon in weapons) 
            {
                choices.Add(weapon.Name);
            }
            IO.Out("Choose a Weapon:");
            int chosenWeapon = IO.MakeChoice(choices, "🗡> ");
            return weapons[chosenWeapon];
        }

        private Attack chooseAttack(Weapon weapon) 
        {
            List<string> choices = new List<string>();
            foreach (Attack attack in weapon.Attacks) 
            {
                choices.Add(attack.Name + " (" + attack.Damage + " DMG)");
            }
            IO.Out("Choose an Attack:");
            int chosenAttack = IO.MakeChoice(choices, "⚔️> ");
            return weapon.Attacks[chosenAttack];
        }

        private int monsterInput(int min, int max) 
        {
            return new Random().Next(min, max);
        }

        private void displayStats() 
        {
            IO.Out("The Good Guys: ");
            foreach (Player p in Players) 
            {
                IO.Out($"   {p.Name} - ({p.Health}/{p.MaxHealth} HP)");
            }
            IO.Out("The Bad Guys: ");
            foreach (Monster m in Monsters)
            {
                IO.Out($"   {m.Name} - ({m.Health}/{m.MaxHealth} HP)");
            }
            IO.Out("\n");
        }
    }
}
