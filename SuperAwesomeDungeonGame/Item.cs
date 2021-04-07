using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAwesomeDungeonGame
{
    class Item
    {
        public string Name;
        public int Amount;
        public bool IsStackable;

        public Item(string _name, bool _isStackable) 
        {
            Name = _name;
            Amount = 1;
            IsStackable = _isStackable;
        }

        public Item(Item other) 
        {
            other.Name = Name;
            other.Amount = Amount;
            other.IsStackable = IsStackable;
        }

        public Item() 
        {
            Name = "Buggy Item Right Here!";
            Amount = 0;
            IsStackable = false;
        }
    }
}
