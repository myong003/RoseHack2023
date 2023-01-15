using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendableBlock : MonoBehaviour
{
    public Transform stretchingBlock;
    public Transform topHeight;
    public bool isStretching;
    public int currentLevel;
    public float minLevel = 1;
    public float maxLevel = 3;
    public float scaleSpeed = 1;         // How fast the blocks rise/fall
    protected float nextHeight;
    protected float levelHeight = 5;      // How tall each level raise is
    protected int movingDirection;

    protected void Start() {
        isStretching = false;
    }

    protected void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            ExtendBlock(1);
        }
        if (Input.GetKeyDown(KeyCode.T)) {
            ExtendBlock(-1);
        }

        if (isStretching) {
            float currHeight = topHeight.TransformPoint(topHeight.position).y;
            if (movingDirection > 0 && currHeight < nextHeight) {
                stretchingBlock.localScale += new Vector3(0, 1, 0) * scaleSpeed * Time.deltaTime;
            }
            else if (movingDirection < 0 && currHeight > nextHeight) {
                stretchingBlock.localScale -= new Vector3(0, 1, 0) * scaleSpeed * Time.deltaTime;
            }
            else {
                isStretching = false;
            }
        }
    }

    /// <summary>
    /// Extends a block a certain height.
    /// </summary>
    /// <param name="level">
    /// How many levels the block with increase/decrease by
    /// </param>
    public void ExtendBlock(int levelChange) {
        if (currentLevel + levelChange <= maxLevel && currentLevel + levelChange >= minLevel) {
            float currHeight = topHeight.TransformPoint(topHeight.position).y;
            isStretching = true;
            nextHeight = currHeight + levelChange * levelHeight;
            movingDirection = levelChange;
            currentLevel += levelChange;
        }
    }
}
