using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSnowBall : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    void Start()
    {
        player = GameObject.FindObjectOfType<character>().transform;
        target = new Vector2(player.position.x, player.position.y);

    } 
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyBullet();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Attack player");
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
