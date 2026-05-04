using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseButton : MonoBehaviour
{
    //loads the shop
    public void ShopPage()
    {
        SceneManager.LoadSceneAsync("Shop");
    }

}
