using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowQuest : MonoBehaviour
{
    public GameObject questUI;
    private int collision = 0;
    public AudioClip sound;
    private AudioSource audio;
    public static int currentScore;

    private bool alreadyPlayed = false;

    void Start()
    {
        questUI.GetComponent<TMP_Text>().text = "find the missing tires";
        audio = GetComponent<AudioSource>();
        questUI.SetActive(false);

    }

    void OnTriggerEnter(Collider other)
    {
       // if (other.tag =="Player" && questUI.activeSelf && collision == 0 && alreadyPlayed == false)
        {
            questUI.SetActive(true);
            audio.PlayOneShot(sound, 5);
            alreadyPlayed = true;
        }


    }
    void OnTriggerExit(Collider other)
    {
     if(other.gameObject.tag =="Player" )
        {
            //questUI.SetActive(false);
            collision = 1;
        }
    }

    private void Update()
    {
        
        if (GlobalScore.currentScore == 4)
        { questUI.GetComponent<TMP_Text>().text = " find a mechanic";}
        if (GlobalScore.currentScore == 5)
        { questUI.GetComponent<TMP_Text>().text = " talk with the mechanic"; }
        if (GlobalScore.currentScore == 6)
        { questUI.GetComponent<TMP_Text>().text = " go back to your car"; }


    }


}
