using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAwesomeDungeonGame
{
    class Attack
    {
        public string Name;
        public double Damage;

        public Attack(string _name, double _damage) 
        {
            Name = _name;
            Damage = _damage;
        }
        public Attack(Attack other)
        {
            this.Name = other.Name;
            this.Damage = other.Damage;
        }
    }
}
