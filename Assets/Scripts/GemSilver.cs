using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemSilver : MonoBehaviour
{
    public GameObject scoreBox;
    public AudioSource collectSound;


    void OnTriggerEnter()
    {
        Destroy(gameObject);
        collectSound.Play();
        GlobalScore.currentScore += 1000;
    }
}
