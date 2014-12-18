using action_game.sources.model.sound.BGM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.sound.BGM
{
    public class BGMPlayer
    {
        public delegate void OnPlayEnd();

        class BGMDevice
        {
            public BGMDevice(ISoundPlayable _playable)
            {
                playable = _playable;
            }

            public void Play(String bgm, float fadeTime, float delayedIn, float delayedOut, bool isLoop, OnPlayEnd _onPlayEnd)
            {
                sound = new BGMSound(bgm);

                sound.Play(playable, fadeTime, delayedIn, delayedOut, isLoop);

                onPlayEnd = _onPlayEnd;
            }

            public void Play(String bgm, float fadeTime)
            {
                Play(bgm, fadeTime, 0.0f, 0.0f, false, null);
            }

            public void Play()
            {
                if (sound != null)
                {
                    sound.Play(playable, 0.0f, 0.0f, 0.0f, false);
                }
            }

            public void Pause()
            {
                if (sound != null)
                {
                    sound.Pause(playable);
                }
            }

            public void Stop(float fadeTime, float delayedStop)
            {
                if (sound != null)
                {
                    sound.Stop(playable, fadeTime, delayedStop);
                }
            }

            public void Stop(float fadeTime)
            {
                if (sound != null)
                {
                    sound.Stop(playable, fadeTime);
                }
            }

            public void Update(float deltaTime)
            {
                if (sound != null)
                {
                    sound.Update(playable, deltaTime);

                    if (playable.IsFinished() && !playable.IsLoop())
                    {
                        if (null != onPlayEnd)
                        {
                            onPlayEnd();
                            onPlayEnd = null;
                        }
                    }
                }
            }

            public ISoundPlayable playable { get; set; }
            public BGMSound sound { get; set; }

            private OnPlayEnd onPlayEnd;
        };

        public BGMPlayer(ISoundPlayable playable1, ISoundPlayable playable2)
        {
            front = new BGMDevice(playable1);
            back = new BGMDevice(playable2);
        }

        public void Play(String bgm)
        {
            Play(bgm, 0.0f, 0.0f, 0.0f, 0.0f, false, null);
        }

        public void Restart()
        {
            front.Play();
            back.Play();
        }

        public void Play(String bgm, float fadeInTime, float fadeOutTime, float delayedIn, float delayedOut, bool isLoop, OnPlayEnd onPlayEnd)
        {
            front.Stop(fadeOutTime, delayedIn);

            //  frontとbackいれかえ
            var tmp = back;
            back = front;
            front = tmp;

            front.Play(bgm, fadeInTime, delayedIn, delayedOut, isLoop, onPlayEnd);
        }

        public void Pause()
        {
            front.Pause();
            back.Pause();
        }

        public void Stop(float fadeTime)
        {
            front.Stop(fadeTime);
            back.Stop(fadeTime);
        }

        public void Update(float deltaTime)
        {
            front.Update(deltaTime);
            back.Update(deltaTime);
        }

        BGMDevice front;
        BGMDevice back;
    }
}
