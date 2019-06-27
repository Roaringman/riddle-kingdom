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
        GameObject[] rainyDays;
        GameObject targetSeeds;
        Vector3 endPos;
        CloudScript rainCloudPrefab;
        int seedIndex = 0;
        static int merges = 0;

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
            rainyDays = FindGameObjectsWithName("RainyDay(Clone)");
            //TODO: Move original seed object rather than creating clones?
 

            if (rainyDays[seedIndex] != null)
            {
                rainCloudPrefab = (CloudScript)rainyDays[seedIndex].GetComponent(typeof(CloudScript));
                endPos = new Vector3 (rainCloudPrefab.transform.position.x, 2.61f, rainCloudPrefab.transform.position.z);
                
            }
            else
            {
                 endPos = avgPos;
            }

            var seq = LeanTween.sequence();
            seq.append(0.5f); // delay everything
            seq.append(LeanTween.move(this.cloudObj, endPos, speed).setEase(LeanTweenType.easeOutQuad)); // do a tween

            seq.append(() =>
            { // fire event after tween
                this.cloudObj.gameObject.SetActive(false);
                merges += 1;
                if (merges == 5)
                {
                    rainCloudPrefab.TriggerCLoudEvent();
                }
         
            });

            seq.append(() => { // fire event after tween
                if (rainCloudChild.activeState == false)
                {
                    rainCloudParent.transform.position = endPos;
                    rainCloudParent.transform.position += new Vector3(0,2f,0);
                    rainCloudChild.activeState = true;
                } else
                {
                    rainCloudChild.cloud.transform.localScale += new Vector3(1f, 1f, 1f);
                    rainCloudChild.cloud.transform.position += new Vector3(0, 1f, 0);
                }
            }); 
        }

        GameObject[] FindGameObjectsWithName(string name)
        {
            GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();
            GameObject[] arr = new GameObject[gameObjects.Length];
            int FluentNumber = 0;
            for (int i = 0; i < gameObjects.Length; i++)
            {
                if (gameObjects[i].name == name)
                {
                    arr[FluentNumber] = gameObjects[i];
                    FluentNumber++;
                }
            }
            Array.Resize(ref arr, FluentNumber);
            return arr;
        }
    }
}
