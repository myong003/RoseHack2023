using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{

    private bool pickupInRange = false, carryingObject = false;
    private GameObject pickupObject = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {   
        if (Input.GetButtonDown("Pickup") && pickupInRange && !carryingObject){
            PickUp();
            carryingObject = true;
        }
        else if (Input.GetButtonDown("Pickup") && pickupInRange && carryingObject){
            Drop();
            carryingObject = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Pickup"){
            pickupInRange = true;
            pickupObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Pickup"){
            pickupInRange = false;
            pickupObject = null;
        }
    }

    void PickUp(){
        pickupObject.transform.parent = gameObject.transform;
        pickupObject.transform.localPosition = new Vector3(0, -0.25f, 1.25f);
    }

    void Drop(){
        pickupObject.transform.parent = null;
    }
}