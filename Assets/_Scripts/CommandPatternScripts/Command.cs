using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPattern
{
    //The parent class
    public abstract class Command : MonoBehaviour
    {
        //How far should the box move when we press a button
        
        protected Transform playerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;

        //Move and maybe save command
        public abstract void Execute(GameObject boxTrans, Command command);

        //Undo an old command
        public virtual void Undo(GameObject boxTrans) { }

        //Move the box
        public virtual void Place(GameObject boxTrans) { }
    }
}