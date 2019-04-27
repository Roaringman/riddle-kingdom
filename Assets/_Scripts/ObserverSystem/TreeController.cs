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
            //The boxes should jump if the sphere is cose to origo
            if (ObservedObject.childCount == 5 && !notified)
            {
                notified = true;
                foreach (Transform child in ObservedObject)
                {
                    CloudObserver childObj = new CloudObserver(child.gameObject, new CloudLerp());

                    x += child.position.x;
                    z += child.position.z;


                    subject.AddObserver(childObj);
                }

                x = x / ObservedObject.childCount;
                z = z / ObservedObject.childCount;
                subject.Notify(new Vector3(x,0f,z));
                
            }
        }
    }
}