using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public float lookSpeed = 5.0f;
    public bool shouldRotate = true;

    // will be either 10.0 or -10.0 depending on the look direction
    private float m_LookAngles = 30.0f;

    // sets a threshold to the head rotation scan path.
    [SerializeField] private float m_LookThreshold = 60.0f;

    // rotate the head to the left or to the right. If we reach a certain point
    // beyond which we deem it unrealistic to "bend" the character's neck, revert to
    // rotating to the opposite direction.
private void RotateToSimulateLook()
    {
        // rotate the head
        transform.Rotate(Vector3.up, m_LookAngles * Time.deltaTime * lookSpeed);
        // if we surpass m_LookThreshold degrees rotation to the right
        if (transform.rotation.eulerAngles.y > m_LookThreshold &&
        transform.rotation.eulerAngles.y < 180.0f ||
        transform.rotation.eulerAngles.y < (360.0f - m_LookThreshold) &&
        transform.rotation.eulerAngles.y > 180.0f)
        {
            // change lookAngles to its opposite
            //m_LookAngles = -m_LookAngles;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // if for some reason we have a negative value in lookThreshold, switch it to its positive value
        if (m_LookThreshold < 0.0f)
            m_LookThreshold = -m_LookThreshold;

    }

    // Update is called once per frame
    void Update()
    {
        // if the head should be rotating, rotate it!
        if (shouldRotate)
            RotateToSimulateLook();
    }
}
