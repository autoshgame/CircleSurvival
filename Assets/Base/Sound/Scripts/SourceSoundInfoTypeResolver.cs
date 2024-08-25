using System;
using UnityEngine;

namespace AutoShGame.Base.Sound
{
    public class SourceSoundInfoTypeResolver
    {
        public Type ResolveType()
        {
            return typeof(AudioSourceImpl);
        }
    }
}
