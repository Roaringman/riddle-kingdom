using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

    public GameObject cube;


    public void changeColor()
    {

        Renderer rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.green);
    }
}
