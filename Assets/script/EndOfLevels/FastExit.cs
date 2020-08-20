using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastExit : MonoBehaviour
{
    public void OnClickQuit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
