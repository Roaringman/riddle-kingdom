using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOnButton : MonoBehaviour {

    public GameObject popUpBtn;


    public void flipVisibility()
    {
        popUpBtn.SetActive(!popUpBtn.activeSelf);
    }



}
