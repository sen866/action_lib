using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.executor.image
{
    interface IEffectable
    {
        bool IsPlayed();
        void execute(ScenarioPlayer player, Action<ScenarioCharacter> appender, Action<ScenarioCharacter> remover);
    }
}
