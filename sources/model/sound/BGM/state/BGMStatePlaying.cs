using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.sound.BGM.state
{
    class BGMStatePlaying : BGMState
    {
        public BGMStatePlaying()
        {
        }

        public BGMState Play(ISoundPlayable playable, String bgm, float fadeInTime, float delayedIn, float delayedOut, bool isLoop)
        {
            return this;
        }

        public BGMState Pause(ISoundPlayable playable)
        {
            playable.Pause();
            return new BGMStatePause(this);
        }

        public BGMState Stop(ISoundPlayable playable, float fadeOutTime, float delayedStop)
        {
            if (fadeOutTime < 0.0f)
            {
                // フェードアウトなし
                return new BGMStateNoFadeOut(delayedStop);
            }

            return new BGMStateFadeOut(fadeOutTime);
        }

        public BGMState Update(ISoundPlayable playable, float deltaTime)
        {
            return this;
        }
    }
}
