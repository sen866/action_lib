using JsonFx.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.stage
{
    public enum StageKind : int
    {
        Undefined = -1,
        First = 1,
        Light = First,
        Earth,
        Green,
        Water,
        Fire,
        Dark,
        Last,
    }
}
