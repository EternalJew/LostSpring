using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionPlatform : MonoBehaviour
{
    private Vector3 initialScale;
    private bool ShouldDestroy = false;
    private SpriteRenderer sprite;
    [SerializeField] private float _timeToRevert;


    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        initialScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        StartCoroutine(CheckDestroy());
    }
    private void Destroy()
    {
        
        ShouldDestroy = true;
    }
    private IEnumerator CheckDestroy()
    {
        while (true)
        {
            if (ShouldDestroy)
            {
                for (int i = 0; i < 3; i++)
                {
                    sprite.enabled = false;
                    yield return new WaitForSeconds(0.33f);
                    transform.localScale = new Vector3(initialScale.x, initialScale.y / 2, initialScale.z);
                    sprite.enabled = true;
                    yield return new WaitForSeconds(0.33f);
                    transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
                }
                sprite.enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                ShouldDestroy = false;
                StartCoroutine(Revert());
            }
            
            yield return null;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<character>() != null)
        {
            Destroy();
        }
    }
    
    private IEnumerator Revert()
    {
        yield return new WaitForSeconds(_timeToRevert);

        Debug.Log("Revert");

        sprite.enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

}
