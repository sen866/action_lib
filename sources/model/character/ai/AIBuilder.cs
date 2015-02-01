using action_game.sources.model.character.ai.think;
using action_game.sources.model.character.ai.think.state;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai
{
    public static class AIBuilder
    {
        static public AIController buildThinkByState(List<ThinkReceipe> receipes)
        {
            return new AIController(
                new ThinkByState(
                    receipes
                    )
                );
        }
    }
}
