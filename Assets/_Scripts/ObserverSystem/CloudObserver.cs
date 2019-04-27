using UnityEngine;
using System.Collections;
using System;

namespace CommandPattern
{
    public class CloudObserver : Observer
    {
        //The box gameobject which will do something
        GameObject cloudObj;
        //What will happen when this box gets an event
        CloudEvents cloudEvent;

        public CloudObserver(GameObject cloudObj, CloudEvents cloudEvent)
        {
            this.cloudObj = cloudObj;
            this.cloudEvent = cloudEvent;
        }

        //What the box will do if the event fits it (will always fit but you will probably change that on your own)
        public override void OnNotify(Vector3 avgPos)
        {
            float speed = cloudEvent.GetLerpSpeed();
            Debug.Log(speed);
            Vector3 endPos = avgPos;
            //this.cloudObj.GetComponent<Transform>().position = endPos;

            LeanTween.move(this.cloudObj, endPos, speed).setEase(LeanTweenType.easeOutQuad);

        }
    }
}
