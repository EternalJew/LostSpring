using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallShootingEnemy : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float speed;
    [SerializeField] private float stoopingDistance;
    [SerializeField] private float nearDistance;
    [SerializeField] private float StartTimeBtwShots;
    [SerializeField] private int directionInput;
    [SerializeField] private bool facingRight = true;
    [SerializeField] private LayerMask groundLayer;

    private float timeBtwShoots;
    [Header("References")]
    public GameObject shot;
    private Transform player;
    void Start()
    {
        player = GameObject.FindObjectOfType<character>().transform;
    }
    private void FixedUpdate()
    {
        //CheckGround();
        IsGrounded();

    }
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < nearDistance)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime );
        }
        else if (Vector2.Distance(transform.position, player.position) > stoopingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoopingDistance && Vector2.Distance(transform.position, player.position) > nearDistance)
        {
          
            transform.position = this.transform.position;
        }
        if (timeBtwShoots <= 0)
        {
            Instantiate(shot, transform.position, Quaternion.identity);
            timeBtwShoots = StartTimeBtwShots;
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
       
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;
        Debug.DrawRay(position, direction, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }





}
