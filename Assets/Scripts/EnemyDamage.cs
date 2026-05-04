using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //sets variables such as the server health
    public int damage = 1;
    private ServerHealth Health;

    //deals damage to the server on collision
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
