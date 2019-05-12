using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearpBears : MonoBehaviour {

    public GameObject bigBear;
    public GameObject littleBear; 


	// Use this for initialization
	void Start () {


        StartCoroutine(LeapBear());	
	}

    IEnumerator LeapBear()
    {
        LeanTween.scale(littleBear, new Vector3(0.52658f, 0.52658f, 0.52658f), 2f);
        LeanTween.scale(bigBear, new Vector3(1f, 1f, 1.5f), 2f);
        yield return new WaitForSeconds(2.0f);

    }
	
}
