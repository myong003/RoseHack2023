using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBuilding : MonoBehaviour
{
    public float rotateSpeed = 5; 

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, rotateSpeed*Time.deltaTime, 0);
    }
}
