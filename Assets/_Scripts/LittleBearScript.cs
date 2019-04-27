using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBearScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}


    public void Sleep()
    {

        gameObject.GetComponent<Animator>().Play("Sleep"); 

    }

}
