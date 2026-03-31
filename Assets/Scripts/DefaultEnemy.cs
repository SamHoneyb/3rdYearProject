using UnityEngine;

public class DefaultEnemy : MonoBehaviour
{
    private Transform Server;
    public float Speed;
    public int Health;
    bool Frozen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Server = GameObject.FindGameObjectWithTag("Server").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Frozen == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, Server.transform.position, Speed * Time.deltaTime);

            if(transform.position.x > Server.transform.position.x)
            {
                FlipEnemy();
            }
        }
        
    }

    public void TakeDamage(int ammount)
    {
        Health -= ammount;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FlipEnemy()
    {
        transform.localScale = new Vector3(-1, 1, 1);
    }

    public void Freeze ()
    {
        Frozen = true;
        
    }

    public void UnFreeze()
    {
        Frozen = false;
    }
}
