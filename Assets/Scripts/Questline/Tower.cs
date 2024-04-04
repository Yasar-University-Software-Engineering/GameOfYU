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
    private float audioLength;

    void OnTriggerEnter(Collider other)
    {
        if (!isTriggeredEnter)
        {
            float audioLength = audio.clip.length;
            GlobalScore.currentScore++;
            audio.Play();
            audio1.PlayDelayed(audioLength);
            isTriggeredEnter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!isTriggeredExit)
        {
            GlobalScore.currentScore++;
            isTriggeredExit = true;
        }
    }
}
