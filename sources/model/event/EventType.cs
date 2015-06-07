using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model
{
    [Serializable]
    public enum GameEventTypes
    {
        None,
        StartGame,
        CompleteScenario,
        AllMinionKilled,
        AllBossMinionKilled,
        DeadPlayer,
        StageClear,
        GameOver,
        GameClear,
    }

    [Serializable]
    public enum ActionEventTypes
    {
        Dead,
    }
}
