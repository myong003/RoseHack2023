using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public GameObject[] ladderBlocks;
    public GameObject currentRespawnPoint;

    public GameObject previousRespawnPoint;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player"){
            foreach (GameObject currentBlock in ladderBlocks)
            {
                currentBlock.SetActive(true);
            }
            currentRespawnPoint.SetActive(true);
            previousRespawnPoint.SetActive(false);
        }
    }
}
