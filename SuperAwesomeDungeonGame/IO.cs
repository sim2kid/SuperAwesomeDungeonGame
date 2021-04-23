using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SuperAwesomeDungeonGame
{
    static class IO
    {
        public static void Out(object toPrint) 
        {
            Console.Write(toPrint.ToString() + "\n");
        }
        public static void OutAdd(object toPrint)
        {
            Console.Write(toPrint.ToString());
        }
        public static string In(object toPrint) 
        {
            return In(toPrint, "> ");
        }
        public static string In(object toPrint, object prefix)
        {
            Out(toPrint);
            Console.Write(prefix.ToString());
            string toReturn = Console.ReadLine();
            Out("\n");
            return toReturn;
        }
        public static int MakeChoice(List<string> choices)
        {
            return MakeChoice(choices, "> ");
        }
        public static int MakeChoice(List<string> choices, object prefix)
        {
            while (true) 
            {
                try
                {
                    int count = 1;
                    foreach (string choice in choices)
                    {
                        Out(count + ") " + choice);
                        count++;
                    }
                    string input = In("", prefix);
                    int toReturn = Int32.Parse(input);
                    if (toReturn > count || toReturn < 1)
                    {
                        Out("Input must be between 1 and " + (count-1) + ".");
                    }
                    else
                    {
                        return toReturn - 1;
                    }
                }
                catch (Exception e) 
                {
                    Out("Input must be a number.");
                }
            }
        }
        public static string[] ListenCommands(object toPrint, object prefix) 
        {
            while (true)
            {
                try
                {
                    string command = In(toPrint, prefix);
                    string[] parts = Regex.Split(command.Trim().ToLower(), "\\s+");
                    return parts;
                }
                catch (Exception e)
                {
                    Out("I don't understand.");
                }
            }
        }
        public static string LoadFile(string fileName) 
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"assets\", fileName);
                string str = File.ReadAllText(path);
                return str;
            }
            catch (Exception e) 
            {
               IO.Out(e);
               return null;
            }
        }
        public static CommandJSON ToJSON(string toParse) 
        {
            CommandJSON json = JsonConvert.DeserializeObject<CommandJSON>(toParse);
            return json;
        }
    }
}
