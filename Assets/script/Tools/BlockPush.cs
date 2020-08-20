using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPush : MonoBehaviour
{
    public GameObject block;

    // Update is called once per frame
    void FixedUpdate()
    {
        block.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    
}
