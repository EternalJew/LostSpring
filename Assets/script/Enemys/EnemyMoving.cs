using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : Unit
{
    public int EnemySpeed;
    public int XMoveDirection;

    private bool shouldDie = false;
    private float deathTimer = 0;
    public float timeBeforeDestroy = 1.0f;

    private SpriteRenderer sprite;
    private Vector3 initialScale;
    public GameObject Flower;

    private enum EnemyState
    {
        dead,
        falling
    }
    private EnemyState state = EnemyState.falling;

    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        initialScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        StartCoroutine(CheckCrushed());

    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;

        if (hit.distance < 0.35f)
        {
            Flip();
        }
    }
    public void Crush()
    {
        state = EnemyState.dead;
        GetComponentInChildren<Collider2D>().enabled = false;
        GetComponentInChildren<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        shouldDie = true;
    }

    private IEnumerator CheckCrushed()
    {
        while (true)
        {
            if (shouldDie)
            {
                for (int i = 0; i < 3; i++)
                {
                    sprite.enabled = false;
                    yield return new WaitForSeconds(0.33f);
                    transform.localScale = new Vector3(initialScale.x, initialScale.y / 2, initialScale.z);
                    sprite.enabled = true;
                    yield return new WaitForSeconds(0.33f);
                }

                shouldDie = false;
                GameObject flower = Resources.Load("Flowers/Flower") as GameObject;
                flower.transform.position = this.transform.position;
                Instantiate(flower);
                Destroy(this.gameObject);
            }

            yield return null;
        }
    }
    void Flip()
    {
        if (XMoveDirection > 0)
        {
            Vector3 direction = transform.right * Input.GetAxis("Horizontal");
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, EnemySpeed * Time.deltaTime);
            sprite.flipX = direction.x < 1F;
            XMoveDirection = -1;
        }
        else
        {
            Vector3 direction = transform.right * Input.GetAxis("Horizontal");
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, EnemySpeed * Time.deltaTime);
            sprite.flipX = direction.x < 0F;
            XMoveDirection = 1;

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<character>() != null)
        {
           
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Crush();

            Rigidbody2D rigidbody = collision.GetComponent<Rigidbody2D>();
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(transform.up * 2f, ForceMode2D.Impulse);
        }
    }
}

