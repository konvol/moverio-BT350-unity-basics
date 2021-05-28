using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLanding : MonoBehaviour
{
    // indicates whether the foot has landed on the Ground
    public bool hasLanded = false;
    
    // reference to access the Head of the Creeper
    public GameObject head;

    // reference to access the Rigidbody component of this GameObject
    private Rigidbody m_Rigidbody;

    // if we have touched the Ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            hasLanded = true;
            m_Rigidbody.useGravity = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // retrieve reference to this GameObject's Rigidbody Component
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the Creeper has landed, command it to start looking around
        if (hasLanded)
        {
            //head.GetComponent<LookAround>().shouldRotate = true;
        }
    }
}
