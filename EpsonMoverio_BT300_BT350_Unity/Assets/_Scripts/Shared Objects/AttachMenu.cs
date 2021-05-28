using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttachMenu : MonoBehaviour
{
    public RectTransform ui;
    public bool enabled;
    private void Start()
    {
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(enabled){
            Vector3 menuPos = Camera.main.WorldToScreenPoint(this.transform.position);
            ui.transform.position = menuPos;
        }

    }
}
