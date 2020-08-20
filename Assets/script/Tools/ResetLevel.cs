using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    private float _touchStartTime;

    [SerializeField] private float _timeToReset = 0.4f;
    private int _scoreOnStart;

    private void Start()
    {
        _scoreOnStart = character.Score;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        character.Score = _scoreOnStart;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //character.lives = _scoreOnStart;
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _touchStartTime = Time.time;
        }
        if (Input.GetKey(KeyCode.R))
        {
            float deltaTime = Time.time - _touchStartTime;
            if (deltaTime > _timeToReset)
            {
                Restart();
            }
        }
    }
}
