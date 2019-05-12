using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool honeyButtonActive = false;
    public GameObject sendMessageButton;
    public GameObject youWon;
    public GameObject seedsButton; 

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
