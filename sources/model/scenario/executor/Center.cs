using action_game.sources.model.scenario.executor.image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.executor
{
    class Center : IScenarioExecutor
    {
        public Center(IScenarioNode node)
        {
            effectable = Creator.create(node.GetAttribute("effect").Value, node.GetAttribute("character").Value);
        }

        public bool IsPlayed(IScenarioNode parent)
        {
            return effectable.IsPlayed();
        }

        public void Play(ScenarioPlayer player, IScenarioNode parent)
        {
            effectable.execute(player, player.AddCenterSide, player.RemoveCenterSide);
        }

        private IEffectable effectable { get; set; }
    }
}
