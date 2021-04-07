using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAwesomeDungeonGame
{
    class Creature
    {
        public double MaxHealth;
        public double Health;
        public string Name;

        public Creature(string _name, double _maxHealth) 
        {
            Name = _name;
            MaxHealth = _maxHealth;
            Health = MaxHealth;
        }

        public double Heal(double _amount) 
        {
            Health += Math.Abs(_amount);
            Health = Math.Clamp(Health, 0, MaxHealth);
            return Health;
        }
    }
}