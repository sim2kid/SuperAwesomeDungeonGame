using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAwesomeDungeonGame
{
    class Player : Creature
    {
        protected Inventory inventory;

        public Player(string _name, double _maxHealth) : base(_name, _maxHealth)
        {
            inventory = new Inventory();
        }
    }
}
