using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 4f;

    private Rigidbody2D rb;
    private Animator animator;

    private float moveInput;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
      
        moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput > 0)
            facingRight = true;
        else if (moveInput < 0)
            facingRight = false;

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        AnimateCharacter();
    }

    void AnimateCharacter()
    {
        if (moveInput != 0)
        {
            if (facingRight)
                animator.Play("Walk");
            else
                animator.Play("WalkLeft");
        }
        else
        {
            if (facingRight)
                animator.Play("IdleRight");
            else
                animator.Play("IdleLeft");
        }
    }
}