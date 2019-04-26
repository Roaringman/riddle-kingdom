using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeLerper : MonoBehaviour
{
    public float height;

    public GameObject bee;
    //public GameObject spawnAbove;
    Vector3 pointA;
    Vector3 pointB;


    void Start()
    {

        pointA = new Vector3(transform.position.x - randomOffset(), transform.position.y + height + 0.3f, transform.position.z + randomOffset());
        pointB = new Vector3(transform.position.x + randomOffset(), transform.position.y + height + 0.3f, transform.position.z - randomOffset());

    }
    void Update()
    {
        bee.transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time / 3.7f, 1));
    }


    float randomOffset()
    {
        float offset = Random.Range(-0.5f, 0.5f);
        return offset;
    }


    float randomSpeed()
    {
        float speed = Random.Range(3f, 4f);
        return speed;
    }

}

