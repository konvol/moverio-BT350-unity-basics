using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkController : MonoBehaviour
{

    // indicates whether the character should be moving or not
    public bool isMoving = false;
    // speed of the Leg movement
    public float moveSpeed = 1.0f;
    // indicates whether the Leg is allowed to move or not.
    private bool m_StartMoving = false;
    // specifies the direction in which the Leg moves on the y-Axis.
    private float m_MoveDirection = 1.0f;
    // height threshold to where we want our Leg to reach before going down
    [SerializeField] private float m_CutoffHeight = -0.40f;
    // Stores the current height of our Creeper
    [SerializeField] private float m_DefaultHeight = -0.55f;
    // delay introduced to simulate feet movement in different phases
    public float stepDelay = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if (m_StartMoving)
                SimulateStep();
        }
        else RevertToRestPose();
    }

    private void RevertToRestPose()
    {
        if (transform.localPosition.y > m_DefaultHeight)
        {
            // calculate how much to translate
            float yTranslate = moveSpeed * Time.deltaTime * -1.0f;
            // translate the Leg
            transform.Translate(0, yTranslate, 0);
        }
    }

    private void SimulateStep()
    {
        // calculate how much to translate
        float yTranslate = moveSpeed * Time.deltaTime * m_MoveDirection;
        // translate the Leg
        transform.Translate(0, yTranslate, 0);
        // if the Leg *local* position exceeds our cutoff height, it should move
        // downard in the y-Axis
        if (transform.localPosition.y >= m_CutoffHeight)
                    m_MoveDirection = -1.0f;
        // if the Leg *local* position exceeds our initial defaulr height, it should
        // move upward in the y-Axis
        else if (transform.localPosition.y <= m_DefaultHeight)
                    m_MoveDirection = 1.0f;

    }

    IEnumerator DelayStepForSeconds(float delay)
    {
        // wait for the designated amount of seconds, then allow movement
        // to commence
        yield return new WaitForSeconds(delay);
        m_StartMoving = true;
    }
    public void ShouldMove()
    {
        StartCoroutine(DelayStepForSeconds(stepDelay));
        isMoving = true;
    }

    public void ShouldStop()
    {
        isMoving = false;
        m_StartMoving = false;
    }

}
