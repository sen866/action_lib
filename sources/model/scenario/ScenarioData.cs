using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario
{
    public class ScenarioData
    {
        public ScenarioData()
        {
            Characters = new List<ScenarioCharacter>();
        }
        public List<ScenarioCharacter> Characters { get; set; }
        public IScenarioNode ScenarioRoot { get; set; }
    }
}
