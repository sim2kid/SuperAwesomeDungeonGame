using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAwesomeDungeonGame
{
    class Monster : Creature
    {
        public Weapon Weapon;

        public Monster(string _name, double _health) : base(_name, _health)
        {
            Weapon = null;
        }
        public Monster(string _name, double _health, Weapon _weapon) : base(_name, _health)
        {
            Weapon = _weapon;
        }
    }
}
