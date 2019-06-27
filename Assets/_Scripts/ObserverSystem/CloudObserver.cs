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
        RainCloud rainCloudChild;


        int test = 0;

        public CloudObserver(GameObject cloudObj, CloudEvents cloudEvent)
        {
            this.cloudObj = cloudObj;
            this.cloudEvent = cloudEvent;
            rainCloudParent = GameObject.Find("RainCloudParent");

            rainCloudChild =  new RainCloud(rainCloudParent.transform.Find("cloud").gameObject);
            Debug.Log(rainCloudChild.cloud.name);
        }

        public override void OnNotify(Vector3 avgPos)
        {
            float speed = cloudEvent.GetLerpSpeed();

            

            //rainCloudObj = rainCloudParent.transform.Find("RainCloud").gameObject;


            Vector3 endPos = avgPos;

            var seq = LeanTween.sequence();
            seq.append(0.5f); // delay everything one second
            seq.append(LeanTween.move(this.cloudObj, endPos, speed).setEase(LeanTweenType.easeInQuint)); // do a tween

            seq.append(() =>
            { // fire event after tween
                this.cloudObj.gameObject.SetActive(false);
                rainCloudChild.merges = 1;
                Debug.Log(rainCloudChild.merges);
                tester();
            });

            seq.append(() => { // fire event after tween
                if (rainCloudChild.activeState == false)
                {
                    Debug.Log(rainCloudChild.activeState);
                    rainCloudParent.transform.position = endPos;
                    rainCloudParent.transform.position += new Vector3(0,2f,0);
                    rainCloudChild.activeState = true;
                } else
                {
                    Debug.Log(rainCloudChild.activeState);
                    rainCloudChild.cloud.transform.localScale += new Vector3(1f, 1f, 1f);
                    rainCloudChild.cloud.transform.position += new Vector3(0, 1f, 0);
                }
            }); 



        }

        void tester()
        {
            test += test  + 1;
            Debug.Log(test);
        }
    }
}
