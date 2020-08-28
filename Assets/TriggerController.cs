using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerController : MonoBehaviour
{

    public UnityEvent OnTrigger;

    private void Start()
    {
        if(OnTrigger == null)
        {
            OnTrigger = new UnityEvent();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<BoxPhysics>() != null)
        {
            OnTrigger.Invoke();
        }
    }

}
