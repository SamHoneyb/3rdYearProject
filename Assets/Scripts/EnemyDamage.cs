using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 1;
    private ServerHealth Health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Server")
        {
            Destroy(gameObject);
            Health = collision.gameObject.GetComponent<ServerHealth>();
            Health.TakeDamage(damage);
        }
    }
}
