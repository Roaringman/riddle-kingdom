﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPattern
{
    public abstract class Observer : MonoBehaviour
    {
        public abstract void OnNotify(Vector3 avgPos);
    }

    //Invokes the notificaton method
    public class Subject
    {
        //A list with observers that are waiting for something to happen
        List<Observer> observers = new List<Observer>();

        //Send notifications if something has happened
        public void Notify(Vector3 avgPos)
        {
            for (int i = 0; i < observers.Count; i++)
            {
                //Notify all observers even though some may not be interested in what has happened
                //Each observer should check if it is interested in this event
                observers[i].OnNotify(avgPos);
            }
        }

        //Add observer to the list
        public void AddObserver(Observer observer)
        {
            observers.Add(observer);
        }

        //Remove observer from the list
        public void RemoveObserver(Observer observer)
        {
        }
    }
}