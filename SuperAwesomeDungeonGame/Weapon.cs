using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAwesomeDungeonGame
{
    class Weapon : Item
    {
        public List<Attack> Attacks;
        public Weapon(string _name, bool _isStackable) : base(_name, _isStackable)
        {
            Attacks = new List<Attack>();
        }

        public Weapon(Weapon other) : base(other.Name, other.IsStackable)
        {
            this.Amount = other.Amount;
            Attacks = new List<Attack>(other.Attacks);
        }

        public void AddAttack(Attack toAdd) 
        {
            Attacks.Add(toAdd);
        }
        public void RemoveAttack(Attack toRemove)
        {
            Attacks.Remove(toRemove);
        }
    }
}
