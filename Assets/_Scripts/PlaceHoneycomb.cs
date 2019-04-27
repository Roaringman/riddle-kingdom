using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHoneycomb : MonoBehaviour {

    GameObject honeyButton;


    // Use this for initialization
    void Start () {

        honeyButton = GameObject.Find("Place Honeycomb");

        TurnOffButton(); 

    }

    public void TurnOnButton()
    {
        honeyButton.SetActive(true);
    }

    public void TurnOffButton()
    {
        honeyButton.SetActive(false);
    }
	
}
