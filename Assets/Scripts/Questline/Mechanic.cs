using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanic : MonoBehaviour
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
        if(!isTriggeredEnter)
        {
            float audioLength = audio.clip.length;
            GlobalScore.currentScore += 1;
            audio.Play();
            audio1.PlayDelayed(audioLength);
            isTriggeredEnter = true;
            }
      

    }

    private void OnTriggerExit(Collider other)
    {
        

        if (!isTriggeredExit) { 
        transform.SetPositionAndRotation(new Vector3(car.transform.position.x, 0.85561f, car.transform.position.z+5), Quaternion.identity);
        GlobalScore.currentScore += 1;

        Transform parentTransform = car.transform;
        int childCount = parentTransform.childCount;
        int startIndex = Mathf.Max(0, childCount - 4);
        for (int i = startIndex; i < childCount; i++)
        {
            Transform child = parentTransform.GetChild(i);
            child.gameObject.SetActive(true);
        }
        car.transform.SetPositionAndRotation(new Vector3(car.transform.position.x, car.transform.position.y + 0.2f, car.transform.position.z),Quaternion.identity);
         isTriggeredExit = true;   
        }
        
    }

    
}
