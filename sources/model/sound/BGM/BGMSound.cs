using action_game.sources.model.sound.BGM.state;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.sound.BGM
{
    class BGMSound
    {
        public BGMSound(String _bgm)
        {
            bgm = _bgm;

            nowState = new BGMStateWait();
        }

        public void Play(ISoundPlayable playable, float fadeInTime, float delayedIn, float delayedOut, bool isLoop)
        {
            nowState = nowState.Play(playable, bgm, fadeInTime, delayedIn, delayedOut, isLoop);
        }

        public void Pause(ISoundPlayable playable)
        {
            nowState = nowState.Pause(playable);
        }

        public void Stop(ISoundPlayable playable, float fadeOutTime, float delayedStop)
        {
            nowState = nowState.Stop(playable, fadeOutTime, delayedStop);
        }

        public void Stop(ISoundPlayable playable,float fadeOutTime)
        {
            nowState = nowState.Stop(playable, fadeOutTime, 0.0f);
        }

        public void Update(ISoundPlayable playable,float deltaTime)
        {
            nowState = nowState.Update(playable, deltaTime);
        }


        private String bgm { get; set; }
        private BGMState nowState = null;
    }
}
