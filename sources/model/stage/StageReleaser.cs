using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.stage
{
    public static class StageReleaser
    {
        public static void Release(StageKind kind)
        {
            var data = StageClearDataHolder.StageClearData.Find(kind);
            data.Released = true;
        }

        public static void ReleaseNext(StageKind kind)
        {
            if (StageKind.Last <= kind + 1)
            {
                return;
            }
            var data = StageClearDataHolder.StageClearData.Find(kind + 1);
            data.Released = true;
        }
    }
}
