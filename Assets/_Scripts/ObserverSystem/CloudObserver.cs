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
        GameObject rainCloudParent;

        public CloudObserver(GameObject cloudObj, CloudEvents cloudEvent)
        {
            this.cloudObj = cloudObj;
            this.cloudEvent = cloudEvent;
        }

        public override void OnNotify(Vector3 avgPos)
        {
            float speed = cloudEvent.GetLerpSpeed();
            rainCloudParent = GameObject.Find("RainCloudParent");

            //rainCloudObj = rainCloudParent.transform.Find("RainCloud").gameObject;

            Debug.Log(rainCloudParent.activeSelf);
            Vector3 endPos = avgPos;

            var seq = LeanTween.sequence();
            seq.append(1f); // delay everything one second
            seq.append(LeanTween.move(this.cloudObj, endPos, speed).setEase(LeanTweenType.easeOutQuad)); // do a tween
            seq.append(() => { // fire event after tween
                /*if (!rainCloudObj.activeSelf)
                {
                    rainCloudObj.transform.position = endPos;
                    rainCloudObj.SetActive(true);
                }*/
            }); 

        }
    }
}
