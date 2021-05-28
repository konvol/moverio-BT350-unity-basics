using UnityEngine;
using UnityEngine.UI;

namespace OL    
{
    public class CircularRangeControl : MonoBehaviour
    {
        
        public RectTransform Origin; //center of rotation
        public Image ImageSelected; //drag here the image of type filled radial top
        public Text Angle; //value textual feedback
        [Range(0, 100)] private int _value = 50;
        //public Toggle DeltaChanges; // if on the value can only change by a delta
        public RectTransform button;
        public int Scale = 360; //value scale to use
        public Transform gameObj;
        
        [Range(0, 360)] private int CurrentValue;
        public State CircularButtonState = State.NOT_DRAGGING;
        public Action action = Action.RESIZE;

        public enum State
        {
            NOT_DRAGGING,
            DRAGGING,
        }
        public enum Action
        {
            ROTATE,
            RESIZE
        }
        private void Start()
        {
            float buttonAngle = ((_value / 50.0f) * 180.0f / 360) * 360;
            button.localEulerAngles = new Vector3(0, 0, -buttonAngle);
        }

        private void Update()
        {
            
        }

        public void DragOnCircularArea(bool isClick)
        {
            //we ignore the click event due to dragging in order to 
            //ignore beyond max set with drag and enable it on click / touch
            if (isClick && CircularButtonState == State.DRAGGING)         {
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

            if (_value > 355)
                _value = 360;
            else if (CurrentValue == 360 && _value < 5)
                _value = 360;
            else if (CurrentValue == 0 && _value > 355)
                _value = 0;
            else if (_value < 5)
                _value = 0;
            if (_value <= CurrentValue && Mathf.Abs(CurrentValue - _value) > 180)
                _value = CurrentValue;
            else if (CurrentValue == 0 && _value > 270)
                _value = CurrentValue;

            CurrentValue = _value;
            if(action == Action.RESIZE)
            {
                gameObj.localScale = new Vector3(1, 1, 1) * ((CurrentValue * Scale / 360f) / 200f);
                Angle.text = "" + (int)(CurrentValue * Scale / 360f) + "%";
            }
            else
            {
                //gameObj.localRotation = Quaternion.Euler(x, y, z);
                Angle.text = "" + (int)(CurrentValue * Scale / 100f ) + "°";
            }
            float amount = CurrentValue / 360f;
            ImageSelected.fillAmount = amount;

            float buttonAngle = amount * 360;
            button.localEulerAngles = new Vector3(0, 0, -buttonAngle);
        }
    }
}
