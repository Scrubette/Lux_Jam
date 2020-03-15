using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
   [Range(0, 20)]
    public float maxSpeed = 6;
    [Range(0, 100)]
    public float jumpForce = 20f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool facingRight = true;
    private Rigidbody2D rigid;
    private Vector3 playerScale;
    [SerializeField]
    private bool grounded = false;
    [SerializeField]
    private float groundRadius = 0.2f;
    private float move;
    private float originalSpeed;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        originalSpeed = maxSpeed;

        
        Cursor.visible = true;
    }


    void Update()
    {
        move = Input.GetAxis("Horizontal");
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        EiraJump();
    }

    void FixedUpdate()
    {
        EiraRun();
    }

    void EiraRun()
    {
        if (grounded)
        {
            rigid.velocity = new Vector2(move * maxSpeed, rigid.velocity.y);

        }


        if (move > 0 && !facingRight)
         {
           Flip();
        }

        else if (move < 0 && facingRight)
        {
            Flip();
        }


    }

    void EiraJump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            
            rigid.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            Invoke("JumpReset", 0.15f);

        }
    }

    void Flip()
    {

       facingRight = !facingRight;
        playerScale = transform.localScale;
       playerScale.x *= -1;
        transform.localScale = playerScale;

    }

}