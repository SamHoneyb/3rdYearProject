using UnityEngine;

public class ServerHealth : MonoBehaviour
{
    public int Health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int ammount)
    {
        Health -= ammount;

        if(Health <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
