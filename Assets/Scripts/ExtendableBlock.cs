using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendableBlock : MonoBehaviour
{
    public Transform stretchingBlock;
    public Transform topHeight;
    public bool isStretching;
    private float minHeight;
    private float maxHeight;
    private float scaleSpeed = 1;

    void Start() {
        isStretching = false;
        minHeight = topHeight.TransformPoint(topHeight.position).y;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            Debug.Log("Stretching block");
            Debug.Log(topHeight.TransformPoint(topHeight.position).y);
            ExtendBlock(10);
        }

        if (isStretching) {
            if (topHeight.TransformPoint(topHeight.position).y < maxHeight) {
                stretchingBlock.localScale += new Vector3(0, 1, 0) * scaleSpeed * Time.deltaTime;
            }
            else {
                isStretching = false;
            }
        }
    }

    public void ExtendBlock(float height) {
        isStretching = true;
        maxHeight = height;
    }
}
