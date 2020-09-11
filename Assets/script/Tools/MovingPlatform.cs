using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Platform { }

public class MovingPlatform : MonoBehaviour, Platform
{
    public float TransFormPosRight = -4f;
    public float TransFormPosLeft = 4f;
    public float dirX, moveSpeed = 3f;
    bool moveRight = true;
    
    void Update()
    {
        if (transform.position.x > TransFormPosLeft)
            moveRight = false;
        if (transform.position.x < TransFormPosRight)
            moveRight = true;
        if (moveRight)
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
    }
}
