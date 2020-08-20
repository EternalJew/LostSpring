using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Text;
using System.IO;

public class AddScore : MonoBehaviour
{
    public AudioSource AddScoreMusic;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<character>() != null && collision as CapsuleCollider2D)
        {
            AddScoreMusic.Play();
            ScoreTextScript.coinAmount++;
            ScoreTextScript.Print();
            Destroy(this.gameObject);
        }
    }
}
