using action_game.sources.model.stage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.story
{
    public enum LoadType
    {
        Simple,
        Additive,
    };

    [Serializable]
    public class StoryData
    {
        public GameEventTypes eventType = GameEventTypes.None;
        public String scene = "";
        public LoadType loadType = LoadType.Simple;
    };

    [Serializable]
    public class ScenarioData
    {
        public String scenrio = "";
        public String scene = "";
        public LoadType loadType = LoadType.Simple;
    };

    [Serializable]
    public class StageData
    {
        public StageKind stage = StageKind.Undefined;
        public String scene = "";
        public LoadType loadType = LoadType.Simple;
    };

    public class StoryProvider
    {
        public StoryProvider(List<ScenarioData> _scenarios, List<StageData> _stages)
        {
            scenarios = _scenarios.ToDictionary(_ => _.scenrio);
            stages = _stages.ToDictionary(_ => _.stage);
        }

        public ScenarioData FindScenario(String name)
        {
            ScenarioData result;
            scenarios.TryGetValue(name, out result);

            return result;
        }

        public StageData FindStage(StageKind kind)
        {
            StageData result;
            stages.TryGetValue(kind, out result);

            return result;
        }

        private Dictionary<String, ScenarioData> scenarios { get; set; }
        private Dictionary<StageKind, StageData> stages { get; set; }
    }
}
