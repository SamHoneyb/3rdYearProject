using UnityEngine;
using UnityEngine.SceneManagement;

public class InformationButton : MonoBehaviour
{
    //navigates to the information page
    public void InformationPage()
    {
        SceneManager.LoadSceneAsync("AbilityExplanation");
    }

}
