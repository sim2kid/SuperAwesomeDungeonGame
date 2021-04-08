using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAwesomeDungeonGame
{
    class Inventory
    {
        public List<Item> Items;
        public Inventory() 
        {
            Items = new List<Item>();
        }

        public void AddItem(Item toAdd) 
        {
            if (toAdd.IsStackable)
            {
                foreach (Item item in Items)
                {
                    if (item.Name.Equals(toAdd.Name) && toAdd.IsStackable) 
                    {
                        item.Amount += toAdd.Amount;
                        return;
                    }
                }
            }
            Items.Add(toAdd);
        }

        public void RemoveItem(Item toRemove) 
        {
            foreach (Item item in Items)
            {
                if (item.Name.Equals(toRemove.Name))
                {
                    item.Amount -= toRemove.Amount;
                    if (item.Amount <= 0) 
                    {
                        Items.Remove(item);
                    }
                    return;
                }
            }
        }

        public Item GetItem(string name) 
        {
            foreach (Item item in Items)
            {
                if (item.Name.Equals(name)) 
                {
                    return new Item(item);
                }
            }
            return null;
        }
    }
}