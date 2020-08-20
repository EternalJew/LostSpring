using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.IO;

public class Livesbar : MonoBehaviour
{
    public int CollectLives;
    private  Transform[] hearts = new  Transform[5];
   
    void Awake()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
        }
    }

     public void Refresh(int lives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lives)
                hearts[i].gameObject.SetActive(true);
            else
                hearts[i].gameObject.SetActive(false);
            
        }
    }
    
}
