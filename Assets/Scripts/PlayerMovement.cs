using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D rigidBody;
    public Animator Animator;
    public PlayerAttacks PlayerAttacks;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Default Attack"))
        {
            PlayerAttacks.DefaultAttack();

        }

        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        if(Horizontal > 0 && transform.localScale.x < 0 || Horizontal < 0 && transform.localScale.x > 0)
        {
            FlipPlayer();
        }

        rigidBody.linearVelocity = new Vector3(Horizontal, Vertical) * Speed;

        Animator.SetFloat("Horizontal", Mathf.Abs(Horizontal));
        Animator.SetFloat("Vertical", Mathf.Abs(Vertical));
    }

    

    void FlipPlayer()
    {
        Vector3 flipScale = transform.localScale;
        flipScale.x *= -1;
        transform.localScale = flipScale;
    }
}
