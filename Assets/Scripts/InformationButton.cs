using UnityEngine;
using UnityEngine.SceneManagement;

public class InformationButton : MonoBehaviour
{
    public void InformationPage()
    {
        SceneManager.LoadSceneAsync("AbilityExplanation");
    }

}
