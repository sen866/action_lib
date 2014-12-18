using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.sound.BGM.state
{
    interface BGMState
    {
        BGMState Play(ISoundPlayable playable, String bgm, float fadeInTime, float delayedIn, float delayedOut, bool isLoop);
        BGMState Pause(ISoundPlayable playable);
        BGMState Stop(ISoundPlayable playable, float fadeOutTime, float delayedStop);
        BGMState Update(ISoundPlayable playable, float deltaTime);
    }
}
