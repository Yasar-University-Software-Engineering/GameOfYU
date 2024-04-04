using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowQuest : MonoBehaviour
{
    public GameObject questUI;
    public GameObject questUIBackground;
    private int collision = 0;
    public AudioClip sound;
    private AudioSource audio;
    public static int currentScore;
    public GameObject tire1;
    public GameObject tire2;
    public GameObject tire3;
    public GameObject tire4;
    public GameObject teleporter;
    public GameObject tower;
    public GameObject car;
    public GameObject trashbags;
    public GameObject lollypop;
    public GameObject mechanic;

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
            GlobalScore.currentScore++;
        }
     
    }

    private void Update()
    {
        if (GlobalScore.currentScore == 0)
        {
            Arrow_waypoints.target = car.transform;
        }
            if (GlobalScore.currentScore == 1)
        { questUI.GetComponent<TMP_Text>().text = " check the tower for more information";
            Arrow_waypoints.target = tower.transform; }
        if (GlobalScore.currentScore == 2)
        { questUI.GetComponent<TMP_Text>().text = " you have to finish 3 quest to reveal your tires "; }
        if (GlobalScore.currentScore == 3)
        { questUI.GetComponent<TMP_Text>().text = " clear the trashbags in parks ";
              
        }
        if (GlobalScore.currentScore == 9)
        { questUI.GetComponent<TMP_Text>().text = " find the giant lollypop ";
            Arrow_waypoints.target = lollypop.transform;
        }
        if (GlobalScore.currentScore == 10)
        { questUI.GetComponent<TMP_Text>().text = " DANCE !! ";
            
        }
        if (GlobalScore.currentScore == 11)
        {
            tire1.SetActive(true);
            tire2.SetActive(true);
            tire3.SetActive(true);
            tire4.SetActive(true);
            questUI.GetComponent<TMP_Text>().text = "find your tires on top of the subway entrances "; }

        if (GlobalScore.currentScore == 15)
        { questUI.GetComponent<TMP_Text>().text = " find a mechanic";
            Arrow_waypoints.target = mechanic.transform;
        }
        if (GlobalScore.currentScore == 16)
        { questUI.GetComponent<TMP_Text>().text = " talk to the mechanic"; }
        if (GlobalScore.currentScore == 17)
        {
            teleporter.SetActive(true);
            questUI.GetComponent<TMP_Text>().text = "drive your car to the ferry";
            Arrow_waypoints.target = car.transform;
        }


    }


}
