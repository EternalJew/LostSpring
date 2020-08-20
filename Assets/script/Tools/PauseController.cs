using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Text;
using System.IO;

public class PauseController : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject Controller;
    public GameObject player1;
    public GameObject bonuses;
    public AudioSource PauseOn;
    public AudioSource PauseOff;
    private void Start()
    {
        GameIsPaused = false;
       
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    PauseOn.Play();
        //    if (GameIsPaused)
        //    {
        //        PauseOff.Play();
        //        Resume();
        //    }
        //    else
        //    {
        //        Pause();
        //    }
        //}
    }
    public void PauseOnClick()
    {
        PauseOn.Play();
        if (GameIsPaused)
        {
            PauseOff.Play();
            Resume();
            
            //            pausebuttonsetactivetrue
        }
        else
        {
            Pause();
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Controller.SetActive(true);
        player1.SetActive(true);
        bonuses.SetActive(true);
        GameIsPaused = false;
        Time.timeScale = 1F;
        
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Controller.SetActive(false);
        player1.SetActive(false);
        bonuses.SetActive(false);
        GameIsPaused = true;
        Time.timeScale = 0F;
       
    }
}
