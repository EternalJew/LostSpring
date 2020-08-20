using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;

public class RestartLevelOnClick : MonoBehaviour
{
    private float _touchStartTime;
    private RewaededAd RewardedAd;

    [SerializeField] private float _timeToReset = 0f;
    private int _scoreOnStart;
   

    private void Start()
    {
        _scoreOnStart = character.Score;
        RewardedAd = FindObjectOfType<RewaededAd>();
        //RewardedAd.HandleUserEarnedReward();
        //RewardedAd.HandleRewardedAdClosed();
        Time.timeScale = 1;
            
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        character.Score = _scoreOnStart;
       
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //character.lives = _scoreOnStart;
    }



    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            _touchStartTime = Time.time;
        }
        if (Input.GetKey(KeyCode.J))
        {
            float deltaTime = Time.time - _touchStartTime;
            if (deltaTime > _timeToReset)
            {
                Restart();
            }
        }
    }
}
//Input.GetKeyDown(KeyCode.R)