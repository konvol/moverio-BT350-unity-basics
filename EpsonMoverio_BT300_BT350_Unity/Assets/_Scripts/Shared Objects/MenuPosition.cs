using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPosition : MonoBehaviour
{
    public Transform sharedObject;
    public bool enabled;
    // Start is called before the first frame update
    void Start()
    {
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(enabled)
            this.transform.position = new Vector3(sharedObject.transform.position.x - 2f, sharedObject.transform.position.y - 1.5f, sharedObject.transform.position.z-0.2f);
    }
}
