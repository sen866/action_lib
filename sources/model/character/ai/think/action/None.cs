﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character.ai.think.action
{
    public class None : Actable
    {
        public state.IState Do(ICharacterable own, float now, float deltaTime)
        {
            return new state.Wait();
        }
    }
}
