using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public float distance;
    public LayerMask whatIsLadder;
    private bool isClimbing;
    private float inputVertical;

    private float startGravityScale;
    public float velocity;
   public  void Start()
   {
        rb = GetComponent<Rigidbody2D>();
        startGravityScale = gameObject.GetComponent<Rigidbody2D>().gravityScale;
   }
    public void FixedUpdate()
     {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
        if(hitInfo.collider != null)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                isClimbing = true;
            }
            else
            {
                if(Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.RightArrow))
                {
                    isClimbing = false;
                }
                
            }
        }
        if(isClimbing == true && hitInfo.collider != null)
        {
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
            rb.gravityScale = velocity;
        }
        else
        {
            rb.gravityScale = startGravityScale;
        }
     }
}
