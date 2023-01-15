using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCamera : MonoBehaviour
{
    public Transform Player;
    public float mouseSens;
    float verticalRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Mouse X");
        float yInput = Input.GetAxis("Mouse Y");

        verticalRotation -= yInput * mouseSens;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);
        transform.localEulerAngles = verticalRotation * Vector3.right;

        Player.Rotate(xInput * Vector3.up * mouseSens);
    }
}
