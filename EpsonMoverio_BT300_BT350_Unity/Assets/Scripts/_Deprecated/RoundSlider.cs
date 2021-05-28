using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundSlider : MonoBehaviour
{
    public enum State
    {
        NOT_DRAGGING,
        DRAGGING,
    };
    public Transform Origin; //center of rotation
    public Image _bar;
    public RectTransform button;
    public State CircularButtonState = State.NOT_DRAGGING;
    [Range(0, 100)] public float _value = 100.0f;
    
    public Toggle DeltaChanges; // if on the value can only change by a delta

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /*if (_value >= 0.0f && _value <= 100.0f) 
            ValueChange(_value);*/
    }

    void ValueChange(float value)
    {   
        float amount = (value / 50.0f) * 180.0f / 360;
        _bar.fillAmount = amount;
        float buttonAngle = amount * 360;
        button.localEulerAngles = new Vector3(0, 0, -buttonAngle);

    }

    public void DragOnCircularArea(bool isClick)
    {
        //we ignore the click event due to dragging in order to 
        //ignore beyond max set with drag and enable it on click / touch
        if (isClick && CircularButtonState == State.DRAGGING)
        {
            CircularButtonState = State.NOT_DRAGGING;
            return;
        }

        if (isClick)
            CircularButtonState = State.NOT_DRAGGING;
        else
        {
            CircularButtonState = State.DRAGGING;
        }

        //ValueChange(_value);
        float f = Vector3.Angle(Vector3.up, Input.mousePosition - Origin.position);
        bool onTheRight = Input.mousePosition.x > Origin.position.x;
        int amount = onTheRight ? (int)f : 180 + (180 - (int)f);
        //float amount = (_value / 50.0f) * 180.0f / 360;
        if (!isClick && DeltaChanges.isOn)
        {
            if (amount <= _value && Mathf.Abs(_value - amount) > 180)
                amount  = (int)_value;
            else if (_value == 0 && _value > 270)
                amount  = (int)_value;
        }
        _value = amount;
        _bar.fillAmount = amount / 360f;
        float buttonAngle = amount;
        button.localEulerAngles = new Vector3(0, 0, -buttonAngle);
    }
}
