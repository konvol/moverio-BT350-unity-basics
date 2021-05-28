using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	private Camera cam;
	public float moveSpeed;
	float ZoomMinBound = 0.1f;
	float ZoomMaxBound = 179.9f;

	// Start is called before the first frame update
	void Start()
    {
		cam = GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
		MoveCamera();
	//Debug.Log(cam.fieldOfView);
    }

	void MoveCamera()  //Movement of the plane according to the controller input
	{	
		if (Input.GetKey(KeyCode.UpArrow))
		{
			cam.fieldOfView += moveSpeed;// y++;
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			cam.fieldOfView -= moveSpeed; //y--;
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			cam.transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));
			//x--;
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			cam.transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
			//x++;
		}

		//cam.fieldOfView -= deltaMagnitudeDiff * speed;
		// set min and max value of Clamp function upon your requirement
		//cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, ZoomMinBound, ZoomMaxBound);
	}
}
