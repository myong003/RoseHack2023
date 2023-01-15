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
        if (pickupObject.TryGetComponent(out BallWell well)){
            well.enabled = false;
        }
        pickupObject.transform.parent = gameObject.transform;
        pickupObject.GetComponent<Rigidbody>().isKinematic = true;
        pickupObject.transform.localPosition = new Vector3(0, -0.25f, 1.75f);
    }

    public void Drop(){
        pickupObject.transform.parent = null;
        pickupObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}