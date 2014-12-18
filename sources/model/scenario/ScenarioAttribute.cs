using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.scenario
{
    public class ScenarioAttribute
    {
        public ScenarioAttribute(String name, String value)
        {
            Name = name;
            Value = value;
        }

        public String Name { get; set; }
        public String Value { get; set; }
    }
}
