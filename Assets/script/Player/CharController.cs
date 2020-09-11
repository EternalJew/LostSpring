using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class CharController : MonoBehaviour
{
    private character Character;
    private Animator animator;
    public float playerSpeed;
    public float jumpPower;
    public int directionInput;
    public bool facingRight = true;
    new private Rigidbody2D rigidbody;
    private SpriteRenderer sprite;
    //public Transform groundCheckPoint;
    //public float groundCheckRadius;
    public LayerMask groundLayer;
    //private bool isTouchingGround;


    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        //StartCoroutine(Move());

    }


    void Update()
    {
        if (((directionInput < 0) && (facingRight)) || ((directionInput > 0) && (!facingRight)))
            Flip();
        animator.SetFloat("Speed", Mathf.Abs(directionInput));
            if (Input.GetButtonDown("Jump")) Jump();
        
        // isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
    }

    private IEnumerator Jump()
    {
        while (true)
        {
            if (Input.GetButtonDown("Jump")/*&& isTouchingGround*/)
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpPower);
            yield return null;
        }
    }

    private IEnumerator Move()
    {
        while (true)
        {
            float movement = Input.GetAxis("Horizontal");

            if (movement != 0f)
                rigidbody.velocity = new Vector2(movement * playerSpeed, rigidbody.velocity.y);
            else
                rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);

            yield return null;
        }
    }

    void FixedUpdate()
    {
        

        rigidbody.velocity = new Vector2(playerSpeed * directionInput, rigidbody.velocity.y);
    }

    public void Move(int InputAxis)
    {
        directionInput = InputAxis;

    }

    public void Flip()
    {
        //Character.CreateDust();
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
