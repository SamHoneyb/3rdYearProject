using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScenarioButton : MonoBehaviour
{
    //takes the player to the selected question
    public void SelectedScenarioLoad()
    {
        SceneManager.LoadSceneAsync("SelectedQuestions");
    }
}
