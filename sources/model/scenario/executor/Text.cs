using action_game.sources.model.scenario.executor.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.executor
{
    class Text : IScenarioExecutor
    {
        public Text(String _text, String _effect, float delay)
        {
            effectable = EffectBuilder.Build(_effect, _text, delay);
        }

        public bool IsPlayed(IScenarioNode parent)
        {
            return effectable.IsPlayed(parent);
        }

        private Effectable effectable { get; set; }


        public void Play(ScenarioPlayer player, IScenarioNode parent)
        {
            effectable.Play(player, parent);
        }
    }
}
