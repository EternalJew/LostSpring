using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBulletSpawner : MonoBehaviour
{
    [SerializeField] private float Range;
    [SerializeField] private LayerMask whatIsTargetLayer;
    public Transform target;
    bool detected = false;
    Vector2 direction;
    public GameObject AlarmLight;
    void Start()
    {
        StartCoroutine(Fire());
    }


    void Update()
    {
        Vector2 targetPos = target.position;
        direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction, Range, whatIsTargetLayer);
        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.CompareTag("Player"))
            {
                if (detected == false)
                {
                    detected = true;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;
                    Debug.Log("red");
                }
            }
            else
            {
                if (detected == true)
                {
                    detected = false;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.green;
                    Debug.Log("green");
                }
            }

        }
        else
        {
            if (detected == true)
            {
                detected = false;
                AlarmLight.GetComponent<SpriteRenderer>().color = Color.green;
                Debug.Log("green");
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }


    [SerializeField] private float delay = 0.5f;

    [SerializeField] private GameObject bullet;

    private IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            if (detected)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
        }
    }
}
