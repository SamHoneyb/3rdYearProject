using UnityEngine;
using UnityEngine.SceneManagement;

public class ServerHealth : MonoBehaviour
{
    public int Health;
    public int maxHealth = 25;
    public HealthBar healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetHealth();
        healthBar.MaxHealthBar(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealth()
    {
        Health = maxHealth;
    }

    public void TakeDamage(int ammount)
    {
        Health -= ammount;
        healthBar.ChangeHealthBar(Health);

        if(Health <= 0 )
        {
            Destroy(gameObject);
            SceneManager.LoadSceneAsync("Questions");
        }
    }
}
