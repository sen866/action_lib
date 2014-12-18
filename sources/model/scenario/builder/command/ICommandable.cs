using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.builder.command
{
    interface ICommandable : IScenarioNodeBuildable
    {
        bool HasEndTag();
        
    }
}
