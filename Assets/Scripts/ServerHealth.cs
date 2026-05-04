using UnityEngine;
using UnityEngine.SceneManagement;

public class ServerHealth : MonoBehaviour
{
    //sets variables
    public int Health;
    public int maxHealth = 25;
    public HealthBar healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetHealth();
        healthBar.MaxHealthBar(maxHealth);
    }

    //sets server to max health
    public void SetHealth()
    {
        Health = maxHealth;
    }

    //takes damage from the server when its hit
    public void TakeDamage(int ammount)
    {
        Health -= ammount;
        healthBar.ChangeHealthBar(Health);

        if(Health <= 0 )
        {
            Destroy(gameObject);
            SceneManager.LoadSceneAsync("GameOver");
        }
    }
}
