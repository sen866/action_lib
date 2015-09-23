using JsonFx.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.stage
{
    public class StageClearDataDetail
    {
        public StageClearDataDetail()
        {
            StageKind = StageKind.Undefined;
            Released = false;
            Cleared = false;
        }

        public StageClearDataDetail(StageKind kind)
            : this()
        {
            StageKind = kind;
        }

        public StageKind StageKind { get; set; }
        public bool Released { get; set; }
        public bool Cleared { get; set; }
    }
}
