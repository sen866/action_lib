using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.sound.BGM.state
{
    class BGMStateFadeOut : BGMState
    {
        public BGMStateFadeOut(float _fadeOutTime)
        {
            elapsedTime = 0.0f;
            fadeOutTime = _fadeOutTime;
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
            return this;
        }

        public BGMState Update(ISoundPlayable playable, float deltaTime)
        {
            elapsedTime += deltaTime;

            if (elapsedTime >= fadeOutTime)
            {
                playable.SetVolume(0.0f);
                playable.Stop();
                return new BGMStateWait();
            }
            else
            {
                playable.SetVolume(1.0f - elapsedTime / fadeOutTime);
            }

            return this;
        }

        private float elapsedTime { get; set; }

        private float fadeOutTime { get; set; }
    }
}
