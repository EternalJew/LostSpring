using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorOpening : MonoBehaviour
{
    public GameObject box;
    public GameObject door;

    public UnityEvent OnActivateButton;


    private void Start()
    {
        if(OnActivateButton == null)
        {
            OnActivateButton = new UnityEvent();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "button")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Activate", true);
            door.gameObject.GetComponent<Animator>().SetBool("Activate", true);
            OnActivateButton.Invoke();
        }    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "button")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Activate", false);
            door.gameObject.GetComponent<Animator>().SetBool("Activate", false);
        }
       
    }
}
