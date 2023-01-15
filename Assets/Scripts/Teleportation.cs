using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject firstPortal; 
    public GameObject secondPortal; 
    public GameObject player; 
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
        if ( collision.gameObject.tag == "Player" )
        {
            //Debug.Log("working");
            var temp = new Vector3(secondPortal.transform.position.x, secondPortal.transform.position.y + 1, secondPortal.transform.position.z + 1);
            player.transform.position = temp; 
        }
    }
}
