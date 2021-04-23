using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAwesomeDungeonGame
{
    class Util
    {
        public static bool DiscernDirection(int value, Direction dir)
        {
            return (value & (int)dir) > 0;
        }
    }
}
