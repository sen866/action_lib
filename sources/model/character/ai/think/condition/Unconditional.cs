using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think.condition
{
    class Unconditional : Checkable
    {
        public bool Check(ICharacterable own)
        {
            return true;
        }
    }
}
