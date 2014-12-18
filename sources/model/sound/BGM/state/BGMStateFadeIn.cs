using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.sound.BGM.state
{
    class BGMStateFadeIn : BGMState
    {
        public BGMStateFadeIn(float _fadeInTime)
        {
            elapsedTime = 0.0f;
            fadeInTime = _fadeInTime;
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
            elapsedTime += deltaTime;

            if (elapsedTime >= fadeInTime)
            {
                playable.SetVolume(1.0f);

                return new BGMStatePlaying();
            }
            else
            {
                playable.SetVolume(elapsedTime / fadeInTime);
            }

            return this;
        }

        private float elapsedTime { get; set; }
        private float fadeInTime { get; set; }
    }
}
