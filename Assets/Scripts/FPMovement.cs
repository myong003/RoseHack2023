using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPMovement : MonoBehaviour
{
    public float speed;
    private Vector3 input = Vector3.zero;
    private float movementSpeedPercent = .25f;

    
    void Update()
    {
        input = Vector3.zero;
        input += Vector3.forward * Input.GetAxis("Vertical");
        input += Vector3.right * Input.GetAxis("Horizontal");

        if (input == Vector3.zero) movementSpeedPercent = 0.25f;
        else movementSpeedPercent += 0.006f;
        movementSpeedPercent = Mathf.Clamp(movementSpeedPercent, 0.25f, 1);

       transform.Translate(input.normalized * speed * Time.deltaTime * movementSpeedPercent);
    }
}
