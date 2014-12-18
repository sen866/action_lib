using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.sound.BGM.state
{
    class BGMStatePause : BGMState
    {
        public BGMStatePause(BGMState _beforeState)
        {
            beforeState = _beforeState;
        }

        public BGMState Play(ISoundPlayable playable, String bgm, float fadeInTime, float delayedIn, float delayedOut, bool isLoop)
        {
            playable.Play(bgm, delayedIn, delayedOut, isLoop);
            return beforeState;
        }

        public BGMState Pause(ISoundPlayable playable)
        {
            return this;
        }

        public BGMState Stop(ISoundPlayable playable, float fadeOutTime, float delayedStop)
        {
            playable.Stop();

            return new BGMStateWait();
        }

        public BGMState Update(ISoundPlayable playable,float deltaTime)
        {
            return this;
        }

        private BGMState beforeState { get; set; }
    }
}
