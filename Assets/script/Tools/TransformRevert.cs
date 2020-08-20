using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRevert : MonoBehaviour
{
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.localPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "DieSpace")
        {
            Debug.Log("Revert");
            this.transform.localPosition = startPosition;
            this.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
            this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }
    }
}
