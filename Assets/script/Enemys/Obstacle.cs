using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Text;
using System.IO;

public class Obstacle : Unit
{
    public AudioSource DeductLives;
    /*private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit is character)
        {
            unit.ReceiveDamage();
            Debug.Log("");
        }
    }*/
    private character Character;
    public void Awake()
    {
        Character = FindObjectOfType<character>();
 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        Unit unit = collision.gameObject.GetComponent<Unit>();
        if(unit && unit is character && collision.collider is CapsuleCollider2D)
        {
            DeductLives.Play();
            unit.ReceiveDamage();
          
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            Character.jumpForce = 0f;
            
        }

    }
}
