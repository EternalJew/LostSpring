using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VerticalBouncer : MonoBehaviour
{
    [SerializeField] private bool BounceUp = true;
    [SerializeField] private float _bounceForce = 750f;

    private Collider2D _bounceObject;
    private bool _onBouncer = false;

    public UnityEvent OnBounce;

    private void Start()
    {
        if (BounceUp == false)
        {
            _bounceForce *= -1;
        }

        if(OnBounce == null)
        {
            OnBounce = new UnityEvent();
        }
    }
    private IEnumerator Bounce()
    {
        yield return new WaitForSeconds(0.3f);

        if (_onBouncer)
        {
            gameObject.GetComponent<Animator>().SetBool("Activate", true);
            Rigidbody2D rigidBody = _bounceObject.GetComponent<Rigidbody2D>();
            rigidBody.AddForce(new Vector2(0f, _bounceForce * rigidBody.mass));
            rigidBody.velocity = new Vector3(0, 0, 0);

            OnBounce.Invoke();
        }
        _bounceObject = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DoorOpening>() != null)
        {
            _bounceObject = collision;
            StartCoroutine(Bounce());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DoorOpening>() != null)
        {
            _onBouncer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DoorOpening>() != null)
        {
            _onBouncer = false;
            _bounceObject = null;
            gameObject.GetComponent<Animator>().SetBool("Activate", false);
        }
    }


}