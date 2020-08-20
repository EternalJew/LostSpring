using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public GameObject box;
    public GameObject door;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "button")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Activate", true);
            door.gameObject.GetComponent<Animator>().SetBool("Activate", true);

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
