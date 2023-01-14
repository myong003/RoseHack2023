using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPMovement : MonoBehaviour
{
    public float speed;
    Vector3 input;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input = Vector3.zero;
        
        input += Vector3.forward * Input.GetAxis("Vertical");

        input += Vector3.right * Input.GetAxis("Horizontal");

        transform.Translate(input.normalized * speed * Time.deltaTime);
    }
}
