using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Text;
using System.IO;

public class AddLives : MonoBehaviour
{
    public AudioSource HeartMusic;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.GetComponent<character>() != null && collision as CapsuleCollider2D)
        {

            HeartMusic.Play();
            character player = collision.GetComponent<character>();
            player.AddLives();
            player.livesbar.Refresh(player.Lives);
            Destroy(this.gameObject);
        }
    }
}
