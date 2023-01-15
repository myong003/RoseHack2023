using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereStatus : MonoBehaviour
{
    [HideInInspector]
    public bool isPickedUp = false;

    [HideInInspector]
    public bool isPickupable = true;
    private float timer = 0;
    private float minimumTime = 5f;
    [HideInInspector]
    public bool timerActive = false;
    private Vector3 initialPos;
    
    void Start() {
        initialPos = this.transform.position;
    }

    private void Update() {
        if (timerActive){
            isPickupable = false;
            timer += Time.deltaTime;
        }
        if (timer >= minimumTime){
            timerActive = false;
            timer = 0;
            isPickupable = true;
        }
    }

    public void Respawn() {
        this.transform.position = initialPos;
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

}
