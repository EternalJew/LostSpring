using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Text;
using System.IO;

public class AddKeys : MonoBehaviour
{
    public AudioSource KeysMusic;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<character>() != null && collision as CapsuleCollider2D)
        {
            collision.gameObject.GetComponent<character>().AddKey();
            KeysMusic.Play();
            KeysText.keyAmount++;          
            KeysText.Print();
            Destroy(this.gameObject);
        }
    }
}
