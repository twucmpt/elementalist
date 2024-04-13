using UnityEngine;


public class SceneManager : MonoBehaviour
{
    public void GoToScene(string sceneName) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void Quit() {
        Application.Quit();
    }
}
