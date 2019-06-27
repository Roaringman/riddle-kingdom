using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool honeyButtonActive = false;
    public GameObject sendMessageButton;
    public GameObject youWon;
    public GameObject seedsButton;

    public int count = 0; 

    public void Start()
    {
        sendMessageButton.SetActive(false);
        youWon.SetActive(false);
        seedsButton.SetActive(false); 
    }

    public void HoneyButton()
    {

            honeyButtonActive = true;

    }

    public void HoneyCounter()
    {
        if (count < 1)
        {
            count++;
        }

        else if (count == 1)
        {
            honeyButtonActive = false;
            count = 0;
        }
    }

    public void ActivateSendMessageButton()
    {
        sendMessageButton.SetActive(true); 

    }

    public void EndOfGame()
    {
        youWon.SetActive(true); 

    }

    public void SeedsButton()
    {
        seedsButton.SetActive(true);

    }
}
