using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour {

    public float speed = 1.5f;
    public float rotateSpeed = 5.0f;
    public float changeSpeed = 1.0f;
    public GameObject baseArea;
    private Vector3 baseAreaVector; 

    Vector3 newPosition;

    void Start()
    {
        baseAreaVector = baseArea.transform.position;
        newPosition = new Vector3(Random.Range(baseAreaVector.x - changeSpeed, baseAreaVector.x + changeSpeed), Random.Range(baseAreaVector.y, baseAreaVector.y + changeSpeed), Random.Range(baseAreaVector.z - changeSpeed, baseAreaVector.z + changeSpeed));

    }

    void PositionChange()
    {
        newPosition = new Vector3(Random.Range(baseAreaVector.x - changeSpeed, baseAreaVector.x + changeSpeed), Random.Range(baseAreaVector.y - changeSpeed, baseAreaVector.y + changeSpeed), Random.Range(baseAreaVector.z - changeSpeed, baseAreaVector.z + changeSpeed));
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, newPosition) < 1)
            PositionChange();

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);

        LookAt2D(newPosition);
    }

    void LookAt2D(Vector3 lookAtPosition)
    {
        float distanceX = lookAtPosition.x - baseAreaVector.x;
        float distanceY = lookAtPosition.y - baseAreaVector.y;
        float distanceZ = lookAtPosition.z - baseAreaVector.z;
        float angle = Mathf.Atan2(distanceX, distanceY) * Mathf.Rad2Deg;

        Quaternion endRotation = Quaternion.AngleAxis(angle, Vector3.back);
        transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, Time.deltaTime * rotateSpeed);
    }

}
