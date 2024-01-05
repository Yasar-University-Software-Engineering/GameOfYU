using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SceneTransitionAfterTimeline : MonoBehaviour
{
    public PlayableDirector director; // Timeline'� kontrol etmek i�in PlayableDirector referans�
    public string nextSceneName;      // Ge�i� yap�lacak sahnenin ad�

    void Update()
    {
        // E�er Timeline oynatmas� bitmi�se, belirtilen sahneye ge�i� yap
        if (director.state != PlayState.Playing)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
