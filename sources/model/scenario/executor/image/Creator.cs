using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.executor.image
{
    class Creator
    {
        public static IEffectable create(String type, String image)
        {
            switch (type)
            {
                case "in": return new In(image,image);
                case "out": return new Out(image,image);
                case "change": return new Change(image,image);
            }
            return null;
        }
    }
}
