﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBouncer : MonoBehaviour
{
    [SerializeField] private bool BounceVert = true;
    [SerializeField] private float _bounceForce = 750f;

    private Collider2D _bounceObject;
    private bool _onBouncer = false;

    private void Start()
    {
        if (BounceVert == false)
        {
            _bounceForce *= -1;
        }
    }
    private IEnumerator Bounce()
    {
        yield return new WaitForSeconds(0.1f);

        if (_onBouncer)
        {
            gameObject.GetComponent<Animator>().SetBool("Activate", true);
            Rigidbody2D rigidBody = _bounceObject.GetComponent<Rigidbody2D>();
            rigidBody.AddForce(new Vector2(_bounceForce * rigidBody.mass, 0f ));
            rigidBody.velocity = new Vector3(0, 0, 0);
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
