using UnityEngine;

public class BoxPhysics : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public bool isGrounded = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            rigidbody.velocity = new Vector2(Mathf.Clamp(rigidbody.velocity.x, 0f, 2f), rigidbody.velocity.y);
    }
}
