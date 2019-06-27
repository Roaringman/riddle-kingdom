using UnityEngine;
using System.Collections;

namespace CommandPattern
{
    public class TreeController : MonoBehaviour
    {
        //Will send notifications that something has happened to whoever is interested
        Subject subject = new Subject();
        Transform ObservedObject;

        bool notified = false;

        void Start()
        {
            //Create boxes that can observe events and give them an event to do
            //CloudObserver box1 = new CloudObserver(box1Obj, new CloudLerp());

            ObservedObject = this.transform;
            //Add the boxes to the list of objects waiting for something to happen
            //subject.AddObserver(box1);
        }


        void Update()
        {
            var x = 0f;
            var z = 0f;
            if (ObservedObject.childCount > 0 && ObservedObject.childCount % 5 == 0 && !notified)
            {
                notified = true;
                foreach (Transform child in ObservedObject)
                {
                    var cloudObj = child.gameObject;
                    CloudObserver childObj = new CloudObserver(cloudObj.transform.Find("cloud").gameObject, new CloudLerp());

                    x += child.position.x;
                    z += child.position.z;

                    subject.AddObserver(childObj);
                }

                x = x / ObservedObject.childCount;
                z = z / ObservedObject.childCount;
                subject.Notify(new Vector3(x,0f,z));
                
            } 

            if(ObservedObject.childCount % 5 != 0 && notified)
            {
                notified = false;


            }
        }
    }
}