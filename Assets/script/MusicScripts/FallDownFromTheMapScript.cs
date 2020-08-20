using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Text;
using System.IO;
public class FallDownFromTheMapScript : MonoBehaviour
{
    public AudioSource FallDown;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            FallDown.Play();
        }
    }
}
