using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAwesomeDungeonGame
{
    class CommandJSON 
    {
        public List<Command> commands;
        public List<ShortcutCommands> shortcuts;
    }
    class Command
    {
        public string name;
        public List<string> alts;
    }

    class ShortcutCommands
    {
        public string name;
        public string command;
        public string argument;
    }
}
