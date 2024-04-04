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
    public GameObject dialogueBox;
    private bool isInteracted = false;
    public string InteractionPrompt => _prompt;



    void OnTriggerEnter(Collider other)
    {
        if (!isTriggeredEnter)
        {
            float audioLength = audio.clip.length;
            GlobalScore.currentScore += 1;
            audio.Play();
            audio1.PlayDelayed(audioLength);
            isTriggeredEnter = true;
        }


    }

    public bool Interact(Interactor interactor)
    {
       
            if (!isInteracted)
            {
                transform.SetPositionAndRotation(new Vector3(car.transform.position.x, 0.85561f, car.transform.position.z + 5), Quaternion.identity);
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
            }

          return true;
        }
        
    }

