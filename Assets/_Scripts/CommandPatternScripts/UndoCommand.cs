using UnityEngine;
using System.Collections.Generic;

//Undo one command
namespace CommandPattern
{
    public class UndoCommand : Command
    {
        //Called when we press a key
        public override void Execute(GameObject boxTrans, Command command)
        {
            List<Command> oldCommands = InputHandler.oldCommands;

            if (oldCommands.Count > 0)
            {
                Debug.Log("Trying to undo");
                Command latestCommand = oldCommands[oldCommands.Count - 1];

                //Move the box with this command
                latestCommand.Undo(boxTrans);

                //Remove the command from the list
                oldCommands.RemoveAt(oldCommands.Count - 1);
            }
        }
    }
}