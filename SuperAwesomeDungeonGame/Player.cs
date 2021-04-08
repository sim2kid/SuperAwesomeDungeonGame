using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAwesomeDungeonGame
{
    class Player : Creature
    {
        public Inventory Inventory;

        public Player(string _name, double _maxHealth) : base(_name, _maxHealth)
        {
            Inventory = new Inventory();
        }
    }
}
