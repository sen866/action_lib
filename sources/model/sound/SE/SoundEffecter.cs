using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.sound.SE
{
    public class SoundEffecter
    {
        public SoundEffecter(ISoundPlayable _single, ISoundPlayable _multi, ISoundPlayable _worldSingle)
        {
            single = _single;
            multi = _multi;
            worldSingle = _worldSingle;
        }

        public void Play(string name, SoundEffectType type, float delayedIn, float delayedOut, bool isLoop)
        {
            switch (type)
            {
                case SoundEffectType.Single:
                    single.Play(name, delayedIn, delayedOut, isLoop);
                    break;
                case SoundEffectType.Multi:
                    multi.Play(name, delayedIn, delayedOut, isLoop);
                    break;
                case SoundEffectType.WorldSingle:
                    worldSingle.Play(name, delayedIn, delayedOut, isLoop);
                    break;
            }
        }

        private ISoundPlayable single { get; set; }
        private ISoundPlayable multi { get; set; }
        private ISoundPlayable worldSingle { get; set; }
    }
}
