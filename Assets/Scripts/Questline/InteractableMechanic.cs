using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class InteractableMechanic : MonoBehaviour, IInteractable
{
    public GameObject questUI;
    [SerializeField] private string _prompt;
    public AudioSource audio;

    public AudioSource audio1;
    public GameObject car;
    private bool isTriggeredEnter = false;
    

    private bool isInteracted = false;
    public string InteractionPrompt => _prompt;
    private float audiolength;




    void OnTriggerEnter(Collider other)
    {
        if (!isTriggeredEnter)
        {
           
            GlobalScore.currentScore += 1;
            audio.Play();
            
            isTriggeredEnter = true;
        }


    }

    public bool Interact(Interactor interactor)
    {
       
            if (!isInteracted)
            {
                audio1.Play();
            //transform.SetPositionAndRotation(new Vector3(car.transform.position.x, 0, car.transform.position.z + 5), Quaternion.identity);
                audiolength = audio1.clip.length;
                GlobalScore.currentScore += 1;

                Transform parentTransform = car.transform;
                int childCount = parentTransform.childCount;
                int startIndex = Mathf.Max(0, childCount - 4);
                for (int i = startIndex; i < childCount; i++)
                {
                    Transform child = parentTransform.GetChild(i);
                    child.gameObject.SetActive(true);
                }
                car.transform.SetPositionAndRotation(new Vector3(car.transform.position.x, car.transform.position.y + 0.2f, car.transform.position.z), Quaternion.identity);
                isInteracted = true;
                Invoke("Teleport", audiolength);
            }

          return true;
        }

    private void Teleport()
    {

        transform.SetPositionAndRotation(new Vector3(car.transform.position.x, 0, car.transform.position.z + 5), Quaternion.identity);
    }
        
    }

