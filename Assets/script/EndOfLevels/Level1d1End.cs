using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Text;
using System.IO;

public class Level1d1End : MonoBehaviour
{
  
    public character character;
    private InterstitialADS InterstitialADS;
    
    public GameObject door_1;
    public void Start()
    {
       
        InterstitialADS = FindObjectOfType<InterstitialADS>();
        InterstitialADS.IninInerstitialAd();
    }
    public void Update()
    {
        door_1.SetActive(character.key == 2);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
           
            InterstitialADS.GameOver();
            Time.timeScale = 1;
          

        }
    }
    
}
