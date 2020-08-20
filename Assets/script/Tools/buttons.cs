using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    //private void Update()
    //{
    //    Play();
    //    GotoSettings();
    //    Instagram();
    //    Home();
    //    GotoLevels();
    //    PlayLevel_1();
    //    PlayLevel_2();
    //    PlayLevel_3();
    //    PlayLevel_4();
    //    PlayLevel_5();
    //}
    
    public void PlayLevel1()
    {
        SceneManager.LoadScene("level_1.1");
    }
    public void PlayLevel2()
    {
        SceneManager.LoadScene("level_1.2");
    }
    public void PlayLevel3()
    {
        SceneManager.LoadScene("level_1.3");
    }

    public void Play()
    {
        SceneManager.LoadScene("level_1.1");
    }


    public void GotoSettings()
    {
        SceneManager.LoadScene("setting");
    }

    public void Instagram()
    {
        Application.OpenURL("https://www.instagram.com/?hl=uk");
    } 

    public void Home()
    {
        SceneManager.LoadScene("Front");
    }

    //public void GotoNextLevel()
    //{
    //    SceneManager.LoadScene("level_2(Final)");
    //}

    public void GotoLevels()
    {
        SceneManager.LoadScene("levels");
    }

    public void PlayLevel_1()
    {
        SceneManager.LoadScene("level_1.1");
    }

    public void PlayLevel_2()
    {
        SceneManager.LoadScene("level_1.2");
    }

    public void PlayLevel_3()
    {
        SceneManager.LoadScene("level_1.3");
    }

    public void PlayLevel_4()
    {
        SceneManager.LoadScene("level_1.4");
    }

    public void PlayLevel_5()
    {
        SceneManager.LoadScene("level_1.5");
    }
    public void PlayLevel_6()
    {
        SceneManager.LoadScene("level_1.6");
    }
    public void PlayLevel_7()
    {
        SceneManager.LoadScene("level_1.7");
    }
    public void PlayLevel_8()
    {
        SceneManager.LoadScene("level_1.8");
    }
    public void PlayLevel_9()
    {
        SceneManager.LoadScene("level_1.9");
    }
    public void PlayLevel_10()
    {
        SceneManager.LoadScene("level_1.10");
    }
}