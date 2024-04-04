using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class InteractableGarbageMan : MonoBehaviour, IInteractable
{

    public GameObject questUI;
    public AudioSource audio;
    public AudioSource audio1;
    private bool isTriggeredEnter = false;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    private bool isInteracted = false;



    void OnTriggerEnter(Collider other)
    {
        if (!isTriggeredEnter)
        {
            GlobalScore.currentScore++;
            audio.Play();
            isTriggeredEnter = true;
        }
    }

    public bool Interact(Interactor interactor)
    {

        if (!isInteracted)
        {
            GlobalScore.currentScore++;
            isInteracted = true;
            audio1.Play();

        }
        return true;
    }

}