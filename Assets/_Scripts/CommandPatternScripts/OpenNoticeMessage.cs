using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class OpenNoticeMessage : Command
    {

        // Use this for initialization
        public override void Execute(GameObject spawnPrefab, Command command)
        {
            //Place the GameObject
            Place(spawnPrefab);

            //Save the command
            InputHandler.oldCommands.Add(command);
        }


        public override void Place(GameObject quest)        
        {
            Debug.Log("Hello World");
            Instantiate(quest); 


        }
    }
    
}
