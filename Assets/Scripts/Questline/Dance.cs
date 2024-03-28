using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dance : MonoBehaviour
{
    public GameObject questUI;

    public AudioSource audio;

    public AudioSource audio1;
    public GameObject car;
    private bool isTriggeredEnter = false;

    void OnTriggerEnter(Collider other)
    {
        if (!isTriggeredEnter)
        {
            GlobalScore.currentScore += 1;
            isTriggeredEnter = true;
        }


    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            GlobalScore.currentScore++;

        }
    }
    
}

