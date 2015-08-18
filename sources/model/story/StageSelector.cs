using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.story
{
    public class StageSelector
    {
        private List<StageData> stages { get; set; }

        private IEnumerator<StageData> now { get; set; }

        public StageSelector(List<StageData> _stages)
        {
            stages = _stages;

            now = stages.GetEnumerator();
        }

        public StageData SelectNext()
        {
            if (now.MoveNext())
            {
                return now.Current;
            }
            return null;
        }

        public StageData Select(String stage)
        {
            return stages.Find(_ => _.stage == stage);
        }
    }
}
