using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControlMenuScaler : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        var wantedPos = Camera.main.WorldToViewportPoint(target.position);
        print(Camera.main.fieldOfView);
        //transform.position = wantedPos;
        //        transform.position = target.position + (Vector3.up * target.position.);
    }
}
