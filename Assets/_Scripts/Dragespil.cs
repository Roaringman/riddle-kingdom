using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragespil : MonoBehaviour {

    public GameObject dragon1;
    public GameObject dragon2;
    public GameObject dragon3;
    public GameObject dragon4;
    public GameObject dragonA;
    public GameObject dragonB;
    public GameObject dragonC;
    public GameObject dragonD;
    public GameObject dragon6;
    public GameObject dragon7;
    public GameObject dragon8;
    public GameObject dragon9;
    public Animator chest;
    public AudioSource chest_open;
    public AudioSource dragon_laugh; 

    private int clicCounter = 0; 



    // Use this for initialization
    void Start() {

        dragon1.SetActive(false);
        dragon2.SetActive(false);
        dragon3.SetActive(false);
        dragon4.SetActive(false);
        dragonA.SetActive(false);
        dragonB.SetActive(false);
        dragonC.SetActive(false);
        dragonD.SetActive(false);
        dragon6.SetActive(false);
        dragon7.SetActive(false);
        dragon8.SetActive(false);
        dragon9.SetActive(false);

        StartCoroutine(Shake());

    }

    // Update is called once per frame
    void Update() {

       // if (Time.deltaTime > Random.Range(2f, 6f)) {
       //     StartCoroutine(Shake());  
       // }

    }

    public void SpawnDragonsInChest() {

        if(clicCounter == 0) { 
            StartCoroutine(DragonStart(dragon1, dragon2, dragon3, dragon4));
            StartCoroutine(OpenSound());
            chest.Play("Shake");
        }

        if (clicCounter == 1)
        {
            StartCoroutine(DragonStart(dragonA, dragonB, dragonC, dragonD));
            StartCoroutine(OpenSound());
            chest.Play("Shake");
            //dragon1.SetActive(false);
            //dragon2.SetActive(false);
            //dragon3.SetActive(false);
            //dragon4.SetActive(false);
        }

        if (clicCounter == 2)
        {
            StartCoroutine(DragonStart(dragon6, dragon7, dragon8, dragon9));
            StartCoroutine(OpenSound());
            chest.Play("Shake");
            //dragonA.SetActive(false);
            //dragonB.SetActive(false);
            //dragonC.SetActive(false);
            //dragonD.SetActive(false);
        }

        if (clicCounter >3)
        {
            //chest.Play("Singel Shake");
            //dragon6.SetActive(false);
            //dragon7.SetActive(false);
            //dragon8.SetActive(false);
            //dragon9.SetActive(false);

        }

        clicCounter++; 

    }

    
    IEnumerator DragonStart(GameObject d1, GameObject d2, GameObject d3, GameObject d4)
    {
        yield return new WaitForSeconds(1.2f);
        d1.SetActive(true);
        d2.SetActive(true);
        d3.SetActive(true);
        d4.SetActive(true);

        yield return new WaitForSeconds(2.5f);

        if (clicCounter < 3) { 
            chest.Play("Close");
        }
    }

    IEnumerator Shake() {
        yield return new WaitForSeconds(1f);
        chest.Play("Singel Shake");
    }

    IEnumerator OpenSound() {
        chest_open.Play();

        yield return new WaitForSeconds(0.8f);

        dragon_laugh.Play(); 
    }
}
