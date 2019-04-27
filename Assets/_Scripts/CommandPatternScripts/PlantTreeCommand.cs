
using UnityEngine;


namespace CommandPattern
{
    public class PlantTreeCommand : Command
    {
        Vector3 onGroundSpawn;
        Transform treeParent = GameObject.Find("TreeParent").transform;

        //Called when we press a key
        public override void Execute(GameObject spawnPrefab, Command command)
        {
            //Place the GameObject
            Place(spawnPrefab);

            //Save the command
            InputHandler.oldCommands.Add(command);
        }

        //Undo an old command
        public override void Undo(GameObject spawnPrefab)
        {
            
        }

        //Move the box
        public override void Place(GameObject spawnPrefab)
        {
            Vector3 playerPos = playerTransform.position;
            Vector3 playerDirection = playerTransform.forward;
            Quaternion playerRotation = playerTransform.rotation;

            Vector3 spawnPos = playerPos + playerDirection * InputHandler.spawnDistance;
            onGroundSpawn.Set(spawnPos.x, 0f, spawnPos.z);

            Instantiate(spawnPrefab, onGroundSpawn, Quaternion.Euler(0, 90, 0), treeParent);

          
        }
    }
}