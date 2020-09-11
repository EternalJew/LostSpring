using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1d17End : MonoBehaviour
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
        door_1.SetActive(character.key == 1);

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            SceneManager.LoadScene("level_1.18");
            InterstitialADS.GameOver();
        }
    }
}
