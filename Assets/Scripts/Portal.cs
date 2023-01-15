using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameObject player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        Vector3 newDirection = Vector3.RotateTowards(this.transform.TransformPoint(this.transform.position), player.transform.position, 5, 0);
        this.transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
