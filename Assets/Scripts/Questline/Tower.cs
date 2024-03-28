using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject questUI;

    public AudioSource audio;

    public AudioSource audio1;
    public GameObject car;
    private bool isTriggeredEnter = false;
    private bool isTriggeredExit = false;
    public GameObject dialogueBox;



    void OnTriggerEnter(Collider other)
    {
        if (!isTriggeredEnter)
        {
            GlobalScore.currentScore += 1;
            audio.Play();
            audio1.PlayDelayed(3);
            isTriggeredEnter = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {

        if (!isTriggeredExit)
        { GlobalScore.currentScore++;
            isTriggeredExit = true; 
        }

    }
}
