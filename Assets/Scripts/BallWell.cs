using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWell : MonoBehaviour
{
    public List<ExtendableBlock> blocksToRaise;
    public List<int> levelsToRaise;
    //public Vector3 positionToMoveTo;
    public GameObject well;
    public ParticleSystem particles;
    public Light wellLight;
    public Color wellColor;
    private GameObject cube; 
    private bool inWell = false;

    void Start()
    {
        var main = particles.main;
        wellLight.color = wellColor;
        main.startColor = wellColor;
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

        RaiseBlocks();
        cube.transform.position = targetPosition;
        cube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ ;
        inWell = true;
    }

    private void RaiseBlocks() {
        for (int i=0; i < blocksToRaise.Count; i++) {
            blocksToRaise[i].ExtendBlock(levelsToRaise[i]);
        }
    }

    private void LowerBlocks() {
        for (int i=0; i < blocksToRaise.Count; i++) {
            blocksToRaise[i].ExtendBlock(-levelsToRaise[i]);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if ( collision.gameObject.tag == "Pickup" && !inWell)
        {
            if (!collision.gameObject.GetComponent<SphereStatus>().isPickedUp){
                cube = collision.gameObject;
                var temp = new Vector3(well.transform.position.x, well.transform.position.y + 0.6f, well.transform.position.z);
                //cube.transform.parent.GetComponent<PlayerPickup>().Drop(); 
                wellLight.enabled = true;
                StartCoroutine(LerpPosition (temp, 1.5f));
                cube.GetComponent<SphereStatus>().timerActive = true;
            }
            
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if ( collision.gameObject.tag == "Pickup" && inWell){
            inWell = false;
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            wellLight.enabled = false;
            LowerBlocks();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( inWell == true )
        {
            cube.transform.Rotate(50 * Time.deltaTime, 0, 50 * Time.deltaTime);
        }
    }
}
