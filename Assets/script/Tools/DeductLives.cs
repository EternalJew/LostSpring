using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Text;
using System.IO;

public class DeductLives : MonoBehaviour
{
    public AudioSource ReceiveDamage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ReceiveDamage.Play();
            character player = collision.gameObject.GetComponent<character>();
            player.DeductLives();
            player.livesbar.Refresh(player.Lives);
        }
    }
}
