using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAwesomeDungeonGame
{
    class Treat : Item
    {
        public double HealthUp;
        public Treat(string _name, bool _isStackable) : base(_name, _isStackable)
        {
            HealthUp = 0;
        }

        public Treat(string _name, bool _isStackable, double _healthUp) : base(_name, _isStackable)
        {
            HealthUp = _healthUp;
        }
        public Treat(Treat other) : base(other.Name, other.IsStackable)
        {
            this.Amount = other.Amount;
            this.HealthUp = other.HealthUp;
        }
    }
}
