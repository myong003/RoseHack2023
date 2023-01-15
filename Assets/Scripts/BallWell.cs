using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWell : MonoBehaviour
{
    // Start is called before the first frame update
    //public Vector3 positionToMoveTo;
    public GameObject well;
    private GameObject cube; 
    private bool inWell = false;

    void Start()
    {

    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = cube.transform.position;
        while (time < duration)
        {
            cube.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        cube.transform.position = targetPosition;
        inWell = true;
    }

    void OnTriggerEnter(Collider collision)
    {
        if ( collision.gameObject.tag == "Pickup")
        {
            if (!collision.gameObject.GetComponent<SphereStatus>().isPickedUp){
                cube = collision.gameObject;
                var temp = new Vector3(well.transform.position.x, well.transform.position.y + 1, well.transform.position.z);
                //cube.transform.parent.GetComponent<PlayerPickup>().Drop(); 
                StartCoroutine(LerpPosition (temp, 2));
            }
            
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if ( collision.gameObject.tag == "Pickup"){
            inWell = false; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( inWell == true )
        {
            cube.transform.Rotate(50 * Time.deltaTime, 50 * Time.deltaTime, 50 * Time.deltaTime);
        }
    }
}
