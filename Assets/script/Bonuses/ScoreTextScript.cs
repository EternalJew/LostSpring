using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    private static Text text;
    public static int coinAmount;
    void Start()
    {
        coinAmount = 0;
        text = GetComponent<Text>();
        
    }
    public static void Print()
    {
        text.text = coinAmount.ToString();
        
    }
}
