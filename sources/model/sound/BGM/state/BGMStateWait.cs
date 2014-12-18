using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.sound.BGM.state
{
    class BGMStateWait : BGMState
    {
        public BGMState Play(ISoundPlayable playable, String bgm, float fadeInTime, float delayedIn, float delayedOut, bool isLoop)
        {
            playable.Play(bgm, delayedIn, delayedOut, isLoop);

            if (fadeInTime > 0.0f)
            {
                playable.SetVolume(0.0f);
                return new BGMStateFadeIn(fadeInTime);
            }
            playable.SetVolume(1.0f);
            return new BGMStatePlaying();
        }

        public BGMState Pause(ISoundPlayable playable)
        {
            return this;
        }

        public BGMState Stop(ISoundPlayable playable,float fadeOutTime, float delayedStop)
        {
            return this;
        }

        public BGMState Update(ISoundPlayable playable,float deltaTime)
        {
            return this;
        }
    }
}
