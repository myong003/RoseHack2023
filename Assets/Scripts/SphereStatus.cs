using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereStatus : MonoBehaviour
{
    [HideInInspector]
    public bool isPickedUp = false;
    private Vector3 initialPos;

    void Start() {
        initialPos = this.transform.position;
    }

    public void Respawn() {
        this.transform.position = initialPos;
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

}
