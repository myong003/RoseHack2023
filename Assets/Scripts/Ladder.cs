using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float climbSpeed;
    private bool playerOnLadder = false;
    private GameObject player;
    private GameObject playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCamera = player.transform.GetChild(0).gameObject; 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerCamera.transform.rotation.eulerAngles.x);
        if (Input.GetKey(KeyCode.W) && playerOnLadder && playerCamera.transform.rotation.eulerAngles.x > 100 && playerCamera.transform.rotation.eulerAngles.x < 320){
            player.transform.position += Vector3.up * climbSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.W) && playerOnLadder && playerCamera.transform.rotation.eulerAngles.x < 100 && playerCamera.transform.rotation.eulerAngles.x > 40){
            player.transform.position += Vector3.down * climbSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) && playerOnLadder){
            player.transform.position += Vector3.right * climbSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player"){
            playerOnLadder = true;
            player.GetComponent<Rigidbody>().useGravity = false;
            player.GetComponent<FPMovement>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player"){
            playerOnLadder = false;
            player.GetComponent<Rigidbody>().useGravity = true;
            player.GetComponent<FPMovement>().enabled = true;
        }
    }
}
