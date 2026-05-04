using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D rigidBody;
    public Animator Animator;
    public PlayerAttacks PlayerAttacks;



    // Update is called once per frame
    void Update()
    {
        //uses the players moves on a button press
        if (Input.GetButtonDown("Default Attack"))
        {
            PlayerAttacks.DefaultAttack();

        }

        if (Input.GetButtonDown("Heal Move"))
        {
            PlayerAttacks.HealthMove();

        }

        if (Input.GetButtonDown("Heavy Move"))
        {
            PlayerAttacks.HeavyAttack();

        }

        if (Input.GetButtonDown("Freeze Move"))
        {
            PlayerAttacks.FreezeMove();

        }

        if (Input.GetButtonDown("Earthquake Move"))
        {
            PlayerAttacks.EarthQuakeMove();

        }

        if (Input.GetButtonDown("Ranged Move"))
        {
            PlayerAttacks.RangedMove();

        }


        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        //flips the player based on direction
        if(Horizontal > 0 && transform.localScale.x < 0 || Horizontal < 0 && transform.localScale.x > 0)
        {
            FlipPlayer();
        }

        //moves the player
        rigidBody.linearVelocity = new Vector3(Horizontal, Vertical) * Speed;

        Animator.SetFloat("Horizontal", Mathf.Abs(Horizontal));
        Animator.SetFloat("Vertical", Mathf.Abs(Vertical));
    }

    
    //actually flips the player
    void FlipPlayer()
    {
        Vector3 flipScale = transform.localScale;
        flipScale.x *= -1;
        transform.localScale = flipScale;
    }
}
