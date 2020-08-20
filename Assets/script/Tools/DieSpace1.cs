using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSpace1 : MonoBehaviour
{
    public GameObject respawn;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = other.GetComponent<character>().currentRespawn.transform.position;
        }
    }
}
