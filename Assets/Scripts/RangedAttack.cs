using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    //sets variables
    public Rigidbody2D rigidBody;
    public Vector2 attackDirection = Vector2.right;
    public float timeToLive = 2;
    public int speed = 10;
    public int damage = 1;
    public LayerMask enemyLayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //makes the bullet move
        rigidBody.linearVelocity = attackDirection * speed;
        Destroy(gameObject, timeToLive);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //checks if the bullets hit an enemy
        if ((enemyLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            collision.gameObject.GetComponent<DefaultEnemy>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }




}
