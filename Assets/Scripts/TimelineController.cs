using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SceneTransitionAfterTimeline : MonoBehaviour
{
    public PlayableDirector director; // Timeline'� kontrol etmek i�in PlayableDirector referans�
    


    void Update()
    {
        // E�er Timeline oynatmas� bitmi�se, belirtilen sahneye ge�i� yap
        if (director.state != PlayState.Playing)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
