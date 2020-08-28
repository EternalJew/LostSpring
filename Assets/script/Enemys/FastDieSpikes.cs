using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastDieSpikes : MonoBehaviour
{
    private character character;
    public GameObject CanvasLose;
    public GameObject Controller;
    [SerializeField]private GameObject player;
    [SerializeField] private GameObject BonusPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<character>() != null && collision as CapsuleCollider2D)
        {
            CanvasLose.SetActive(true);
            Controller.SetActive(false);
            player.SetActive(false);
            BonusPanel.SetActive(false);
            character.lives = 5;
            character.Score = 0;
            Destroy(gameObject);
        }
    }
        
        
}
