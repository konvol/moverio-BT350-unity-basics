using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;

[Serializable]


public class ColorEvent : UnityEvent<Color> { }
public class ColorPicker : MonoBehaviour
{
    public ColorEvent OnColorPreview;
    public ColorEvent OnColorSelect;
    RectTransform Rect;
    public RectTransform button;
    public RectTransform Origin;
    Texture2D ColorTexture;
    private int _value = 100;
    private int CurrentValue;
    public State CircularButtonState = State.NOT_DRAGGING;

    public enum State
    {
        NOT_DRAGGING,
        DRAGGING,
    }


    // Start is called before the first frame update
    void Start()
    {
        Rect = GetComponent<RectTransform>();
        ColorTexture = GetComponent<Image>().mainTexture as Texture2D;

    }

    // Update is called once per frame
    void Update()
    {

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

        float f = Vector3.Angle(Vector3.up, Input.mousePosition - Origin.position);
        bool onTheRight = Input.mousePosition.x > Origin.position.x;
        _value = onTheRight ? (int)f : 180 + (180 - (int)f);

        CurrentValue = _value;
        float amount = CurrentValue / 360f;

        float buttonAngle = amount * 360;
        button.localEulerAngles = new Vector3(0, 0, -buttonAngle);

        Vector2 delta;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, Input.mousePosition, null, out delta);

        //This might not be necessary. Converting the width and the hight so the (0,0) to be on the corner of the rectangle
        float width = button.rect.width;//Rect.rect.width;
        float height = button.rect.height;//Rect.rect.height;
        delta += new Vector2(width * .5f, height * .5f);
        //Until here

        //Setting the coordinates to the scale of 0 1. Mathf.Clamp: making sure color will be between 0 1
        float x = Mathf.Clamp(delta.x / width, 0f, 1f);
        float y = Mathf.Clamp(delta.y / height, 0f, 1f);

        int texX = Mathf.RoundToInt(x * ColorTexture.width);
        int texY = Mathf.RoundToInt(y * ColorTexture.height);

        //Getting the color from the pixel of the picture
        Color color = ColorTexture.GetPixel(texX, texY);

        //Setting the color preview

        OnColorPreview?.Invoke(color);
        OnColorSelect?.Invoke(color);
        //if (Input.GetMouseButtonDown(0))
        //{


        //}
    }
}