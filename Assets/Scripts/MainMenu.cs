using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Questions");
    }

    public void Scenes()
    {
        SceneManager.LoadSceneAsync("QuizScenes");
    }

    public void Settings()
    {
        SceneManager.LoadSceneAsync("Settings");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}
