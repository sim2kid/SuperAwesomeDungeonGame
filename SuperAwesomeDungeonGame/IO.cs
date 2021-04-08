using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
