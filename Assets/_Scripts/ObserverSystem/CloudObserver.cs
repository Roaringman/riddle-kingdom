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
        GameObject rainCloudChild;

        public CloudObserver(GameObject cloudObj, CloudEvents cloudEvent)
        {
            this.cloudObj = cloudObj;
            this.cloudEvent = cloudEvent;
        }

        public override void OnNotify(Vector3 avgPos)
        {
            float speed = cloudEvent.GetLerpSpeed();
            rainCloudParent = GameObject.Find("RainCloudParent");
            rainCloudChild = rainCloudParent.transform.Find("cloud").gameObject;

            //rainCloudObj = rainCloudParent.transform.Find("RainCloud").gameObject;


            Vector3 endPos = avgPos;

            var seq = LeanTween.sequence();
            seq.append(1f); // delay everything one second
            seq.append(LeanTween.move(this.cloudObj, endPos, speed).setEase(LeanTweenType.easeInQuint)); // do a tween

            seq.append(() =>
            { // fire event after tween
                this.cloudObj.gameObject.SetActive(false);
            });

            seq.append(() => { // fire event after tween
                if (!rainCloudChild.activeSelf)
                {
                    rainCloudParent.transform.position = endPos;
                    rainCloudParent.transform.position += new Vector3(0,2f,0);
                    rainCloudChild.SetActive(true);
                } else
                {
                    rainCloudChild.transform.localScale += new Vector3(1f, 1f, 1f);
                    rainCloudChild.transform.position += new Vector3(0, 1f, 0);
                }
            }); 

        }
    }
}
