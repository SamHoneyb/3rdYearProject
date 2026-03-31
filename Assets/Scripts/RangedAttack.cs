using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{

    public Rigidbody2D rigidBody;
    public Vector2 attackDirection = Vector2.right;
    public float timeToLive = 2;
    public int speed = 10;
    public int damage = 1;
    public LayerMask enemyLayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody.linearVelocity = attackDirection * speed;
        Destroy(gameObject, timeToLive);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if ((enemyLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            collision.gameObject.GetComponent<DefaultEnemy>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }


}
