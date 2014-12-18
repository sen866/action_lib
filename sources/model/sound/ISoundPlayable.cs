using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.sound
{
    public interface ISoundPlayable
    {
        void Play(String name, float delayedIn, float delayedOut, bool isLoop);

        void Pause();

        void Stop();

        void SetVolume(float volume);

        float GetVolume();

        bool IsPlaying();

        bool IsFinished();

        bool IsLoop();
    }
}
