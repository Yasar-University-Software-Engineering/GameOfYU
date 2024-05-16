using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level1End : MonoBehaviour

{
     
    public GameObject explosionEffect;
    public GameObject car;
    bool isTriggerExit;
    [SerializeField] private string _prompt;
    [SerializeField] private float initialSpeedIncrement = 0.5f;
    [SerializeField] private GameObject fadeCanvas;
    [SerializeField] private Image fadeImage;// Ekraný karartacak Canvas
    public string InteractionPrompt => _prompt;

    private void OnTriggerEnter(Collider other)
        {
        if (!isTriggerExit) {
            Instantiate(explosionEffect, car.transform.position,car.transform.rotation);
            StartCoroutine(TransitionToNextScene());
            isTriggerExit = true;
            
        }
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
