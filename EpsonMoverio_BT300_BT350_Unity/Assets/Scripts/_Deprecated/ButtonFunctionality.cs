using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonFunctionality : MonoBehaviour {
    public GameObject _slider;
    public RectTransform _origin;
    public float circle_radius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector3 v = touchPos - _origin.position;
            Vector3 new_pos = _origin.position + (v.normalized * circle_radius);
            _slider.transform.position = new_pos;
        }
    }

    
}
