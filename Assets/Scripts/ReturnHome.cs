using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnHome : MonoBehaviour
{
    //Takes the player to the home page
    public void HomePage()
    {
        SceneManager.LoadSceneAsync("HomeScreen");
    }
}
