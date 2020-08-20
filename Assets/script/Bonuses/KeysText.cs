using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeysText : MonoBehaviour
{
    private static Text text;
    public static int keyAmount;
    void Start()
    {
        keyAmount = 0;
        text = GetComponent<Text>();
    }
    public static void Print()
    {

        text.text = keyAmount.ToString();
    }
        

    
}
