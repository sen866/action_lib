using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.story
{
    public class ScenarioSelector
    {
        private List<ScenarioData> scenarios {get;set;}

        private IEnumerator<ScenarioData> now { get; set; }

        public ScenarioSelector(List<ScenarioData> _scenarios)
        {
            scenarios = _scenarios;

            now = scenarios.GetEnumerator();
        }

        public ScenarioData SelectNext()
        {
            if (now.MoveNext())
            {
                return now.Current;
            }
            return null;
        }
    }
}
