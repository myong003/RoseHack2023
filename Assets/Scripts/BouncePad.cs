using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{

    public float boostMultiplier = 1.1f;
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
        if (collision.TryGetComponent(out Rigidbody rb)){
            rb.velocity = new Vector3(0, -rb.velocity.y * boostMultiplier, 0);
        }
    }
}