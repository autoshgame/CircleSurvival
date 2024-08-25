using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace AutoShGame.Base.Sound
{
    public class SourceConfigResolver 
    {
        public SourceConfigProps GetSourceConfigs(SourceConfigType typeSource)
        {
            SourceConfigProps sourceConfigProps2D = new SourceConfigProps();

            SourceConfigProps sourceConfigProps3D = new SourceConfigProps();
            sourceConfigProps3D.spatialBlend = 1;

            switch (typeSource)
            {
                case SourceConfigType.TwoD:
                    return sourceConfigProps2D;
                case SourceConfigType.ThreeD:
                    return sourceConfigProps3D;
                default:
                    return sourceConfigProps2D;
            }    
        }
    }

    public enum SourceConfigType
    {
        TwoD,
        ThreeD,
    }

    public class SourceConfigProps
    {
        public AudioRolloffMode rolloffMode;
        public float dopplerLevel;
        public float spread;
        public float minDistance;
        public float maxDistance;
        public float spatialBlend;

        public SourceConfigProps()
        {
            rolloffMode = AudioRolloffMode.Logarithmic;
            dopplerLevel = 1;
            spread = 0;
            minDistance = 1;
            maxDistance = 500;
            spatialBlend = 0;
        }
    }
}


