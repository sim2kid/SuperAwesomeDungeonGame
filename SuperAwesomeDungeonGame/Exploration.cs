using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace SuperAwesomeDungeonGame
{
    class Exploration
    {
        private Room[,] rooms;
        private Vector2 currentPosition;
        private Player player;
        public bool CanLoop;

        public Exploration(int mapSize, Vector2 startingPos) 
        {
            rooms = new Room[mapSize, mapSize];
            currentPosition = startingPos;
            CanLoop = true;
        }

        public void AssignRoom(Room room) 
        {
            rooms[(int)room.Position.X, (int)room.Position.Y] = room;
        }

        public void RunLoop(Player _player) 
        {
            player = _player;
            readDescription();
            while (CanLoop) 
            {
                try
                {
                    string[] input = IO.ListenCommands("What would you like to do?", "> ");
                    string command = (input.Length >= 1) ? input[0] : "";
                    string argument = (input.Length >= 2) ? input[1] : "";
                    RunCommand(command, argument);
                }
                catch (Exception e) 
                {
                    if (e.GetType() == typeof(NotImplementedException))
                        IO.Out("I can't do that yet. Sorry!");
                    else
                        IO.Out("Something strange just happened! Maybe the programmer was drunk when making this game?");
                }
            }
        }

        public void RunCommand(string command, string argument) 
        {
            if (command.ToLower().Equals("shortcut")) 
            {
                IO.Out("I don't understand.");
                return;
            }
            String c = GetCommand(command);
            switch (c) 
            {
                case "shortcut":
                    return;
                case "move":
                    Direction getDir = discernDirection(argument);
                    if (getDir == Direction.None)
                    {
                        IO.Out(command + "?\n" + command + " where?");
                    }
                    else 
                    {
                        onMove(getDir);
                    }
                    break;
                case "pickup":
                    IO.Out("Pickup");
                    throw new NotImplementedException();
                    break;
                case "look":
                    if (argument == null || argument == "")
                    {
                        readDescription();
                    }
                    else 
                    {
                        IO.Out("Look at what?");
                        throw new NotImplementedException();
                    }
                    break;
                case "inventory":
                    onInventory();
                    break;
                case "enter":
                    IO.Out("Enter");
                    throw new NotImplementedException();
                    break;
                case "exit":
                    IO.Out("Exit");
                    throw new NotImplementedException();
                    break;
                case "blowup":
                    IO.Out("Blowup");
                    throw new NotImplementedException();
                    break;
                default:
                    IO.Out("I don't understand.");
                    break;
            }

        }

        private void readDescription() 
        {
            Room room = rooms[(int)currentPosition.X, (int)currentPosition.Y];
            IO.Out(room.Description);
        }

        private void onInventory() 
        {
            IO.Out("Inventory:");
            foreach (Item item in player.Inventory.Items) 
            {
                IO.Out($"- {item.Name}{((item.Amount > 1) ? $" ({item.Amount})" : "")}");
            }
        }

        private Direction discernDirection(string dir) 
        {
            switch (dir.ToLower()) 
            {
                case "up":
                case "north":
                    return Direction.North;
                case "right":
                case "east":
                    return Direction.East;
                case "down":
                case "south":
                    return Direction.South;
                case "left":
                case "west":
                    return Direction.West;
                default:
                    return Direction.None;
            }
        }

        private void onMove(Direction direction) 
        {
            // Check if room has exit
            Room currentRoom = rooms[(int)currentPosition.X, (int)currentPosition.Y];
            if (Util.DiscernDirection(currentRoom.Exits, direction))
            {
                // Move into that room
                switch (direction) 
                {
                    case Direction.North:
                        currentPosition.Y++;
                        break;
                    case Direction.South:
                        currentPosition.Y--;
                        break;
                    case Direction.East:
                        currentPosition.X++;
                        break;
                    case Direction.West:
                        currentPosition.X--;
                        break;
                }
                // X Wrap around
                if (currentPosition.X > rooms.GetLength(0))
                {
                    currentPosition.X -= rooms.GetLength(0);
                }
                else if (currentPosition.X < 0) 
                {
                    currentPosition.X += rooms.GetLength(0);
                }
                // Y Wrap Around
                if (currentPosition.Y > rooms.GetLength(1))
                {
                    currentPosition.Y -= rooms.GetLength(1);
                }
                else if (currentPosition.X < 0)
                {
                    currentPosition.Y += rooms.GetLength(1);
                }
                readDescription();
            }
            else 
            {
                IO.Out("You can't go that way.");
            }
        }

        private string GetCommand(string fromAlt) 
        {
            CommandJSON json = IO.ToJSON(IO.LoadFile("Commands.json"));
            foreach (Command cmd in json.commands)
            {
                string name = cmd.name;
                foreach (String alt in cmd.alts) 
                {
                    if (fromAlt.ToLower().Equals(alt.ToLower())) 
                    {
                        return name;
                    }
                }
            }
            foreach (ShortcutCommands sc in json.shortcuts) 
            {
                if (fromAlt.ToLower().Equals(sc.name.ToLower())) 
                {
                    RunCommand(sc.command, sc.argument);
                    return "shortcut";
                }
            }
            return null;
        }  
    }
}
