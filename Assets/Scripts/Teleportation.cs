using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : ExtendableBlock
{
    public GameObject firstPortal; 
    public GameObject secondPortal;
    public GameObject portalSprite; 
    public bool steppedOut = true;
    public bool isActivated;

    protected override void Start() {
        base.Start();
        if (isActivated) {
            portalSprite.SetActive(true);
        }
        else{
            portalSprite.SetActive(false);
        }
    }
    // Update is called once per frame
    protected override void Update()
    {
        
    }

    public override void ExtendBlock(int levelChange) {
        if (levelChange > 0) {
            isActivated = true;
            portalSprite.SetActive(true);
        }
        else {
            isActivated = false;
            portalSprite.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if ( collision.gameObject.tag == "Player" && steppedOut && isActivated)
        {
            //Debug.Log("working");
            var temp = new Vector3(secondPortal.transform.position.x, secondPortal.transform.position.y + 1, secondPortal.transform.position.z);
            collision.gameObject.transform.position = temp; 
            secondPortal.GetComponent<Teleportation>().steppedOut = false;
        }
    }

    void OnTriggerExit(Collider collision) {
        if ( collision.gameObject.tag == "Player" && !steppedOut)
        {
            steppedOut = true;
        }
    }
}
