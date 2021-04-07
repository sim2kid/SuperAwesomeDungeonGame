using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAwesomeDungeonGame
{
    class Inventory
    {
        private List<Item> items;
        public Inventory() 
        {
            items = new List<Item>();
        }

        public void AddItem(Item toAdd) 
        {
            if (toAdd.IsStackable)
            {
                foreach (Item item in items)
                {
                    if (item.Name.Equals(toAdd.Name) && toAdd.IsStackable) 
                    {
                        item.Amount += toAdd.Amount;
                        return;
                    }
                }
            }
            items.Add(toAdd);
        }

        public void RemoveItem(Item toRemove) 
        {
            foreach (Item item in items)
            {
                if (item.Name.Equals(toRemove.Name))
                {
                    item.Amount -= toRemove.Amount;
                    if (item.Amount <= 0) 
                    {
                        items.Remove(item);
                    }
                    return;
                }
            }
        }

        public Item GetItem(string name) 
        {
            foreach (Item item in items)
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