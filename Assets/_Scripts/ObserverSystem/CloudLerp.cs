using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{

    public abstract class CloudEvents
    {
        public abstract float GetLerpSpeed();
    }

    public class CloudLerp : CloudEvents
    {
        public override float GetLerpSpeed()
        {
            return Random.Range(5f,10f);
        }
    }

}