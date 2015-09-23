using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.stage
{
    public static class StageClearDataHolder
    {
        static StageClearDataHolder()
        {
            StageClearData = new StageClearData();
        }

        public static StageClearData StageClearData { get; set; }
    }
}
