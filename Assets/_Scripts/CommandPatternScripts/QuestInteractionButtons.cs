using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{

    public class QuestInteractionButtons : Command
    {

        // Use this for initialization
        public override void Execute(GameObject spawnPrefab, Command command)
        {
            //Place the GameObject
            Place(spawnPrefab);

            //Save the command
            InputHandler.oldCommands.Add(command);

            InteractWithButton(spawnPrefab); 
        }


        public void InteractWithButton(GameObject quest)
        {    
            Debug.Log("You accepted the quest!");
            Destroy(quest.transform.parent.gameObject); 
            //quest.transform.parent.gameObject.SetActive(false);
            //GameObject.Find("Quest 1Notice(Clone)").SetActive(false); 
        }
    }
}
