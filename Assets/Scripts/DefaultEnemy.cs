using UnityEngine;

public class DefaultEnemy : MonoBehaviour
{
    //sets variables
    private Transform Server;
    public float Speed;
    public int Health;
    bool Frozen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //finds the server
        Server = GameObject.FindGameObjectWithTag("Server").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the enemy can move
        if (Frozen == false)
        {
            //moves the enemy towards the server
            transform.position = Vector2.MoveTowards(transform.position, Server.transform.position, Speed * Time.deltaTime);

            //flips asset depending on what side of the screen its on
            if(transform.position.x > Server.transform.position.x)
            {
                FlipEnemy();
            }
        }
        
    }

    //takes the enemies health
    public void TakeDamage(int ammount)
    {
        Health -= ammount;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //actually flips the enemy 
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
