using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendableRamp : ExtendableBlock
{
    public ExtendableBlock attachedPillar;
    public GameObject ramp;
    private float yOffset = 0.2f;
    private float maxScale = 0.5f;

    protected override void Update() {
        this.transform.position = attachedPillar.topHeight.position + new Vector3(0, yOffset, 0);
        // rb.velocity = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.F)) {
            ExtendBlock(1);
        }

        if (Input.GetKeyDown(KeyCode.G)) {
            ExtendBlock(-1);
        }
    }

    /// <summary>
    /// Grows or shrinks a ramp
    /// </summary>
    /// <param name="levelChange">
    /// If levelChange > 0, ramp will expand to normal size
    /// If levelChange < 0, ramp will shrink and disappear
    /// </param>
    public override void ExtendBlock(int levelChange) {
        if (!isStretching) {
            StartCoroutine(ExtendBlockCoroutine(levelChange));
        }
    }

    private IEnumerator ExtendBlockCoroutine(int direction) {
        isStretching = true;

        if (direction > 0) {
            ramp.SetActive(true);
            // Expanding ramp
            while (stretchingBlock.localScale.x < maxScale) {  
                stretchingBlock.localScale += new Vector3(1, 1, 1) * scaleSpeed * Time.deltaTime;
                yield return null;
            }
            stretchingBlock.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else {
            // Shrinking ramp
            while (stretchingBlock.localScale.x > 0) {    
                stretchingBlock.localScale -= new Vector3(1, 1, 1) * scaleSpeed * Time.deltaTime;
                yield return null;
            }
            ramp.SetActive(false);
            stretchingBlock.localScale = Vector3.zero;
        }

        isStretching = false;
    }
}