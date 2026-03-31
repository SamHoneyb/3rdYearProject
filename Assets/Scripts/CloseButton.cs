using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseButton : MonoBehaviour
{
    public void ShopPage()
    {
        SceneManager.LoadSceneAsync("Shop");
    }

}
