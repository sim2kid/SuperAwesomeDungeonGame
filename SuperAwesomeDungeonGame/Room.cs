using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace SuperAwesomeDungeonGame
{
    class Room
    {
        public Vector2 Position;
        public string Name;
        public string Description;
        public int Exits;

        public Room(Vector2 _position, string _name, string _description, int _exits) 
        {
            Position = _position;
            Name = _name;
            Description = _description;
            Exits = _exits;
        }
    }
}
