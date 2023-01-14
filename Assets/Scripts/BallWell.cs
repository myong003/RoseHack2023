using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWell : MonoBehaviour
{
    // Start is called before the first frame update
    //public Vector3 positionToMoveTo;
    public GameObject well;
    private bool inWell = false;

    void Start()
    {

    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        inWell = true;
    }

    void OnTriggerEnter(Collider collision)
    {
        var temp = new Vector3(well.transform.position.x, well.transform.position.y + 2, well.transform.position.z);
        StartCoroutine(LerpPosition (temp, 2));
    }

    // Update is called once per frame
    void Update()
    {
        if ( inWell == true )
        {
            transform.Rotate(50 * Time.deltaTime, 0, 50 * Time.deltaTime);
        }
    }
}
