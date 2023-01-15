using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{

    private bool pickupInRange = false, carryingObject = false;
    private GameObject pickupObject = null;
    void Update()
    {   
        if (Input.GetButtonDown("Pickup") && pickupInRange && !carryingObject && pickupObject.GetComponent<SphereStatus>().isPickupable){
            PickUp();
            carryingObject = true;
        }
        else if (Input.GetButtonDown("Pickup") && carryingObject){
            Drop();
            carryingObject = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Pickup" && !carryingObject){
            pickupInRange = true;
            pickupObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Pickup" && !carryingObject){
            pickupInRange = false;
            pickupObject = null;
        }
    }

    void PickUp(){
        pickupObject.GetComponent<SphereStatus>().isPickedUp = true;
        pickupObject.transform.parent = gameObject.transform;
        pickupObject.GetComponent<Rigidbody>().isKinematic = true;
        pickupObject.transform.localPosition = new Vector3(0, -0.25f, 1.75f);
        //pickupObject.GetComponent<SphereCollider>().enabled = false;
    }

    public void Drop(){
        pickupObject.GetComponent<SphereStatus>().isPickedUp = false;
        pickupObject.transform.parent = null;
        pickupObject.GetComponent<Rigidbody>().isKinematic = false;
        //pickupObject.GetComponent<SphereCollider>().enabled = true;
    }
}