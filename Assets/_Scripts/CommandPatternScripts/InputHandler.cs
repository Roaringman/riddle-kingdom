using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace CommandPattern
{
    public class InputHandler : MonoBehaviour
    {
        //The box we control with keys
        //public Transform boxTrans;

        public GameObject tree, seed, treeHoneyComb, quest1;
        [SerializeField]
        public static float spawnDistance = 6.5f;

        //The different keys we need
        private Command buttonSeed, buttonTree, buttonTreeHoneyComb, buttonOpenNoticeMessage, buttonUndo;
        //Stores all commands for replay and undo
        public static List<Command> oldCommands = new List<Command>();
        //Box start position to know where replay begins
        private Vector3 boxStartPos;
        //To reset the coroutine
        private Coroutine replayCoroutine;
        //If we should start the replay
        public static bool shouldStartReplay;
        //So we cant press keys while replaying
        private bool isReplaying;

        void Start()
        {
            //Bind keys with commands
            buttonSeed = new PlantSeedCommand();
            buttonTree = new PlantTreeCommand();
            buttonTreeHoneyComb = new PlantTreeHoneyCombCommand();
            buttonOpenNoticeMessage = new OpenNoticeMessage();
            buttonUndo = new UndoCommand();
            //buttonR = new ReplayCommand();

            //boxStartPos = boxTrans.position;
        }



        void Update()
        {
            if (!isReplaying)
            {
               // HandleInput();
            }

            //StartReplay();
        }

        public void PlantTree()
        {
            buttonTree.Execute(tree, buttonTree);
        }

        public void SowSeeds()
        {
            buttonSeed.Execute(seed, buttonSeed);

        }

        public void PlantTreeHoneyComb()
        {
            buttonTreeHoneyComb.Execute(treeHoneyComb, buttonTreeHoneyComb);
        }

        public void OpenNoticeMessage()
        {
            buttonOpenNoticeMessage.Execute(quest1, buttonOpenNoticeMessage); 
        }

        public void UndoCommand()
        {
            buttonUndo.Execute(tree, buttonUndo);
        }


        //Checks if we should start the replay
        void StartReplay(GameObject replayer)
        {
            if (shouldStartReplay && oldCommands.Count > 0)
            {
                shouldStartReplay = false;

                //Stop the coroutine so it starts from the beginning
                if (replayCoroutine != null)
                {
                    StopCoroutine(replayCoroutine);
                }

                //Start the replay
                replayCoroutine = StartCoroutine(ReplayCommands(replayer));
            }
        }


        //The replay coroutine
        IEnumerator ReplayCommands(GameObject replayer)
        {
            //So we can't move the box with keys while replaying
            isReplaying = true;

            //Move the box to the start position
            //boxTrans.position = boxStartPos;

            for (int i = 0; i < oldCommands.Count; i++)
            {
                //Move the box with the current command
                //oldCommands[i].Move(replayer);

                yield return new WaitForSeconds(0.3f);
            }

            //We can move the box again
            isReplaying = false;
        }
    }
}