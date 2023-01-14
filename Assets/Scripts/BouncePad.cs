using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
            collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, -collision.gameObject.GetComponent<Rigidbody>().velocity.y, 0);
    }
}
