using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario
{
    public class ScenarioCharacter
    {
        public ScenarioCharacter(String id, String name)
        {
            Id = id;
            Name = name;
        }

        public String Id { get; set; }
        public String Name { get; set; }
    }
}
