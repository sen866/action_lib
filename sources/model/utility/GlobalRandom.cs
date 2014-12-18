using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.utility
{
    static class GlobalRandom
    {
        static GlobalRandom()
        {
            Generator = new Random();
        }

        public static Random Generator { get; set; }
    }
}
