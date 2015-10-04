using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.stage
{
    public class StageClearData
    {
        public StageClearData()
        {
            StageClears = new List<StageClearDataDetail>();

            for (var kind = StageKind.First; kind < StageKind.Last; ++kind)
            {
                StageClears.Add(new StageClearDataDetail(kind));
            }

            Find(StageKind.First).Released = true;
        }

        public StageClearDataDetail Find(StageKind kind)
        {
            return StageClears.Find(_ => kind == _.StageKind);
        }

        public List<StageClearDataDetail> StageClears { get; set; }
    }
}
