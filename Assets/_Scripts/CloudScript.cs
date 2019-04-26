using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour {

    public GameObject cloudPosition;
    public GameObject clouds;
    public ParticleSystem rain;
    public GameObject flower1;
    public GameObject flower2;
    public GameObject flower3;
    public GameObject fullSizeFlower;
    public GameObject seed1;
    public GameObject seed2;
    public GameObject seed3;
    public GameObject turnOnBtn;
    public GameObject bee;

    public float growFactor= 1.5f; 

    // Use this for initialization
    void Start () {

        
       clouds.SetActive(false);
       rain.gameObject.SetActive(false);
        TriggerCLoudEvent();

    }
	
	// Update is called once per frame
	/*void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TriggerCLoudEvent(); 
        }
        
    }*/


    public void TriggerCLoudEvent() {

        clouds.SetActive(true); 
        LeanTween.move(clouds, cloudPosition.transform.position, 5.0f)
            .setEase(LeanTweenType.easeOutQuad);

        StartCoroutine(RainEvent()); 
    }

    IEnumerator RainEvent() {

        yield return new WaitForSeconds(6);
        rain.gameObject.SetActive(true);

        yield return new WaitForSeconds(3);
        Debug.Log("Flowers grow");

        LeanTween.scale(flower1, fullSizeFlower.transform.localScale, growFactor)
            .setEaseInOutBounce(); 
        LeanTween.scale(flower2, fullSizeFlower.transform.localScale, growFactor)
            .setEaseInOutBounce();
        LeanTween.scale(flower3, fullSizeFlower.transform.localScale, growFactor)
            .setEaseInOutBounce();
        LeanTween.scale(seed1, new Vector3(0, 0, 0), growFactor);
        LeanTween.scale(seed2, new Vector3(0, 0, 0), growFactor);
        LeanTween.scale(seed3, new Vector3(0, 0, 0), growFactor);

        yield return new WaitForSeconds(growFactor + 1.0f);

        prefabSpawner();
        LeanTween.scale(clouds, new Vector3(0, 0, 0), 2.0f)
            .setEaseInOutBounce();

        yield return new WaitForSeconds(2.0f);


        turnOnBtn.GetComponent<turnOnButton>().flipVisibility();

    }

    


    // Use this for initialization
    public void prefabSpawner()
    {

        Vector3 spawnPos = fullSizeFlower.transform.position;

        Instantiate(bee, spawnPos, Quaternion.identity);
    }

    


}
