﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think.condition
{
    public interface Checkable
    {
        bool Check(ICharacterable own);
    }
}
