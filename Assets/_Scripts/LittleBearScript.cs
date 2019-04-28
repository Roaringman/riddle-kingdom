using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBearScript : MonoBehaviour {

    public GameObject bear; 



    public void Angry()
    {

        bear.GetComponent<Animator>().Play("Be_Idle to Stand"); 

    }

}
