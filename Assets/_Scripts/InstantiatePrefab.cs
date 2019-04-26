using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour {

    public GameObject spawnPrefab;
    public GameObject player;
    public GameObject parent;
    public float spawnDistance;
    Vector3 onGroundSpawn;



    // Use this for initialization
    public void prefabSpawner () {

        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
        onGroundSpawn.Set(spawnPos.x,0f,spawnPos.z);

        Instantiate(spawnPrefab, onGroundSpawn, Quaternion.Euler(0, 90, 0));
    }
}
