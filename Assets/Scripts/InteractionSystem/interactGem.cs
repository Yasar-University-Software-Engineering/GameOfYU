using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class interactGem : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private float initialSpeedIncrement = 0.5f;
    [SerializeField] private GameObject fadeCanvas;
    [SerializeField] private Image fadeImage;// Ekraný karartacak Canvas
    private GemRotate gemRotateScript;
    private bool isInteracted = false;
    public string InteractionPrompt => _prompt;

    void Start()
    {
        gemRotateScript = GetComponent<GemRotate>();
        fadeCanvas.SetActive(false); // Baþlangýçta Canvas'ý pasif yap
    }

    void Update()
    {
        if (isInteracted)
        {
            gemRotateScript.rotateSpeed += initialSpeedIncrement * Time.deltaTime;
        }
    }

    public bool Interact(Interactor interactor)
    {
        if (!isInteracted)
        {
            isInteracted = true;
            StartCoroutine(TransitionToNextScene());
        }
        return true;
    }

    IEnumerator TransitionToNextScene()
    {
        float elapsedTime = 0;
        float waitTime = 3f; // Toplam bekleme süresi

        fadeCanvas.SetActive(true);

        while (elapsedTime < waitTime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = elapsedTime / waitTime;
            fadeImage.color = new Color(0, 0, 0, alpha); // Renk deðerini güncelle
            yield return null;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
