using UnityEngine;

public class BaseEnemyHealth : MonoBehaviour
{
    public int Health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int ammount)
    {
        Health -= ammount;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
