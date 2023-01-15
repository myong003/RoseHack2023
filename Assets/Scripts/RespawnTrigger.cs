using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    public GameObject respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider coll) {
        GameObject ob = coll.gameObject;
        Debug.Log("Trigger");
        if (ob.tag == "Player") {
            ob.transform.position = respawnPoint.transform.position;
            ob.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
