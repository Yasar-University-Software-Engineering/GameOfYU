using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class interactObjects : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    private bool isInteracted = false;
    public string InteractionPrompt => _prompt;

    void Start()
    {

        
    }

    void Update()
    {
        
    }

    public bool Interact(Interactor interactor)
    {
        if (!isInteracted)
        {
            isInteracted = true;
            GlobalScore.currentScore += 1;
            Destroy(gameObject);
            

        }
        return true;
    }

  

    
}