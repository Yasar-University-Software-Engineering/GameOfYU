using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SceneTransitionAfterTimeline : MonoBehaviour
{
    public PlayableDirector director; // Timeline'ý kontrol etmek için PlayableDirector referansý

    void Update()
    {
        // Eðer Timeline oynatmasý bitmiþse veya Space tuþuna basýlmýþsa, belirtilen sahneye geçiþ yap
        if (director.state != PlayState.Playing || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
