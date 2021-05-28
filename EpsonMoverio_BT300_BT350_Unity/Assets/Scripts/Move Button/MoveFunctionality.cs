using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveFunctionality : MonoBehaviour
{
    public Image moveContainer;
    public Image moveButton;
    public Image arrowUp;
    public Image arrowDown;
    public Image arrowLeft;
    public Image arrowRight;
    public Transform sharedObject;
    public GameObject menuSphere;

    private bool mouseDown = false;
    private Vector3 startMousePos;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ButtonMove();
        menuSphere.GetComponent<MenuPosition>().enabled = !mouseDown;
        menuSphere.GetComponent<AttachMenu>().enabled = !mouseDown;
    }
    public void OnPointerDown()
    {
        Debug.Log("in pointer down");
        mouseDown = true;
        startPos = moveButton.transform.position;
        startMousePos = Input.mousePosition;
    }

    public void OnPointerUp()
    {
        Debug.Log("in pointer up");
        mouseDown = false;
        startPos = moveButton.transform.position;
    }


    void ButtonMove()
    {
        Vector3 pos;
        Vector3 prevPos = startPos;
        Vector3 parentPos = moveContainer.transform.position;
        if (mouseDown)
        {
            Vector3 currentPos = Input.mousePosition;
            Vector3 diff = currentPos - startMousePos;
            pos = startPos + diff;
            pos.x = Mathf.Clamp(pos.x, parentPos.x - 10f, parentPos.x + 10f);
            pos.y = Mathf.Clamp(pos.y, parentPos.y - 10f, parentPos.y + 10f); //restring the move button to be inside the circle
            
            if(pos.x > prevPos.x) //right movement
            {
                arrowRight.color = Color.cyan;
                sharedObject.transform.position = new Vector3(sharedObject.transform.position.x + 0.005f, sharedObject.transform.position.y, sharedObject.transform.position.z);  
            }
            else
            {
                arrowRight.color = Color.white;
            }

            if (pos.x < prevPos.x) //left movement
            {
                arrowLeft.color = Color.cyan;
                sharedObject.transform.position = new Vector3(sharedObject.transform.position.x - 0.005f, sharedObject.transform.position.y, sharedObject.transform.position.z);
            }
            else
            {
                arrowLeft.color = Color.white;
            }

            if (pos.y > prevPos.y) //up movement
            {
                arrowUp.color = Color.cyan;
                sharedObject.transform.position = new Vector3(sharedObject.transform.position.x, sharedObject.transform.position.y + 0.005f, sharedObject.transform.position.z);
            }
            else
            {
                arrowUp.color = Color.white;
            }

            if (pos.y < prevPos.y) //down movement
            {
                arrowDown.color = Color.cyan;
                sharedObject.transform.position = new Vector3(sharedObject.transform.position.x, sharedObject.transform.position.y - 0.005f, sharedObject.transform.position.z);
            }
            else
            {
                arrowDown.color = Color.white;
            }
        }
        else
        {
            pos = parentPos;
            arrowUp.color = Color.white;
            arrowDown.color = Color.white;
            arrowLeft.color = Color.white;
            arrowRight.color = Color.white;
        }
        moveButton.transform.position = pos;
    }
}
