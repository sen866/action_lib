using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario.executor.image
{
    class Out : IEffectable
    {
        public Out(String id, String image)
        {
            isPlayed = false;
            character = new ScenarioCharacter(id, image);
        }

        public void execute(ScenarioPlayer player, Action<ScenarioCharacter> appender, Action<ScenarioCharacter> remover)
        {
            remover(character);

            isPlayed = true;
        }

        private ScenarioCharacter character { get; set; }

        public bool IsPlayed()
        {
            return isPlayed;
        }

        private bool isPlayed { get; set; }
    }
}
