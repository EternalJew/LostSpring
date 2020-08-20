using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevelWithAD : Unit
{
   // private RewaededAd RewardedAd;
    public GameObject respawn;
    public static bool GameIsWaitingForChoose = false;
    public GameObject pauseMenuUI;
    public GameObject Controller;
    public GameObject player1;
    public GameObject bonuses;
    void Start()
    {
        //RewardedAd = FindObjectOfType<RewaededAd>();
        //RewardedAd.RewardingAd();     
    }  
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = other.GetComponent<character>().currentRespawn.transform.position;
            //RewardedAd.GameOver();
            if (GameIsWaitingForChoose)
            {
                ResumeWindowAd();
            }
            else
            {
                PauseWindowAd();
            }
        }
    }
    public void ResumeWindowAd()
    {
        pauseMenuUI.SetActive(false);
        Controller.SetActive(true);
        player1.SetActive(true);
        bonuses.SetActive(true);      
        Time.timeScale = 1F;
        GameIsWaitingForChoose = false;
    }

    void PauseWindowAd()
    {
        pauseMenuUI.SetActive(true);
        Controller.SetActive(false);
        player1.SetActive(false);
        bonuses.SetActive(false);      
        Time.timeScale = 0F;
        GameIsWaitingForChoose = true;
    }
}
