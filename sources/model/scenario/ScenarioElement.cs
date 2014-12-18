using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using action_game.sources.model.scenario;
using action_game.sources.model.scenario.executor;

namespace action_game.sources.model.scenario
{
    class ScenarioElement : IScenarioNode
    {
        public ScenarioElement()
        {
            children = new List<IScenarioNode>();
            attributes = new Dictionary<String, ScenarioAttribute>();
        }

        public ScenarioElement(IScenarioExecutor executor) : this()
        {
            this.executor = executor;
        }

        public IScenarioNode GetChild(int index)
        {
            return children.ElementAt(index);
        }

        public IEnumerable<IScenarioNode> GetChildren()
        {
            return children;
        }

        public IScenarioExecutor GetExecutor()
        {
            return executor;
        }

        public void SetExecutor(IScenarioExecutor executor)
        {
            this.executor = executor;
        }

        public IScenarioNode AddChild(IScenarioNode node)
        {
            children.Add(node);
            node.Parent = this;
            return node;
        }

        public void AddAttribute(ScenarioAttribute attribute)
        {
            attributes.Add(attribute.Name, attribute);
        }

        public ScenarioAttribute GetAttribute(String name)
        {
            if (attributes.ContainsKey(name))
            {
                return attributes[name];
            }
            return new ScenarioAttribute(name,"");
        }

        public IScenarioNode Parent { get; set; }

        public IScenarioNode Next { get; set; }

        private List<IScenarioNode> children { get; set; }

        private Dictionary<String, ScenarioAttribute> attributes { get; set; }

        private IScenarioExecutor executor { get; set; }
    }
}
