using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerForPlayer : MonoBehaviour
{
    [SerializeField] private bool BounceUp = true;
    [SerializeField] private float _bounceForce;

    private void Start()
    {
        if (BounceUp == false)
        {
            _bounceForce *= -1;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<character>() != null)
        {
            gameObject.GetComponent<Animator>().SetBool("Activate", true);
            Rigidbody2D rigidBody = collision.GetComponent<Rigidbody2D>();
            rigidBody.velocity = new Vector3(0, 0, 0);
            rigidBody.AddForce(new Vector2(0f, _bounceForce * rigidBody.mass));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<character>() != null)
        {
            gameObject.GetComponent<Animator>().SetBool("Activate", false);
        }
    }


}
