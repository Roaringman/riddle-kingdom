using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool honeyButtonActive = false;
    public GameObject sendMessageButton;
    public GameObject youWon; 

    public void Start()
    {
        sendMessageButton.SetActive(false);
        youWon.SetActive(false); 
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
}
