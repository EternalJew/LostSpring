using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportForPlayer : MonoBehaviour
{
    
    [SerializeField] private Transform teleport;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<character>() != null)
        {
            collision.transform.position = teleport.position;
        }
    }
}
