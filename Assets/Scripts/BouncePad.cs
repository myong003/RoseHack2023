using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    private Rigidbody rb; 
    public GameObject player;
    public float boost; 
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if ( collision.gameObject == player )
        {
            player.GetComponent<Rigidbody>().velocity = new Vector2(0, 10);
        }
    }
}
