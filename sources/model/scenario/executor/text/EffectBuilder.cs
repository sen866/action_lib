using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.executor.text
{
    class EffectBuilder
    {
        public static Effectable Build(String effect, String text, float delay)
        {
            switch (effect)
            {
                case "fade": return new Fade(text, delay);
                case "normal": return new Normal(text, delay);
                case "": return new Normal(text, delay);
            }

            return null;
        }
    }
}
