//Tutorial Scene actually shows developers how to use the various Moverio Functions
//of the plugin. 

using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;


public class MoverioTutorialController : MonoBehaviour {

	//sets various ints to handle the sensor values. 
	public  int CUSTOM_SENSOR_COUNT = 6;

	public  int TYPE_HEADSET_ACCELEROMETER = 0;
	public  int TYPE_CONTROLLER_ACCELEROMETER = 1;
	public  int TYPE_CONTROLLER_MAGNETIC_FIELD = 2;
	public  int TYPE_CONTROLLER_GYROSCOPE = 3;
	public  int TYPE_CONTROLLER_ROTATION_VECTOR = 4;
	public  int TYPE_HEADSET_TAP = 5;


	//text views to display the sensor data. 

	public Text TextView0;
	public Text TextView1;
	public Text TextView2;
	public Text TextView3;
	public Text TextView4;
	public Text TextView5;

	public Toggle toggle;
	//public Text tv;
	public static MoverioController controller;
    private bool controllerValues = true;

    void Start () 

	{
		TextView0.text = "";
		TextView1.text = "";
		TextView2.text = "";
		TextView3.text = "";
		TextView4.text = "";
		TextView5.text = "";
		
		//StartCoroutine(TutorialSequence());


	}

	//The following depicts how developers recieve sensor data from the Moverio in Unity. 

	void DisplaySensorData() 
	{
        if (toggle.isOn)
        {
			
			TextView0.text = "CONTROLLER ACCEL x: " + Mathf.Round(MoverioController.Instance.GetSensorData(TYPE_CONTROLLER_ACCELEROMETER)[0]).ToString() + ", " +
				"y: " + Mathf.Round(MoverioController.Instance.GetSensorData(TYPE_CONTROLLER_ACCELEROMETER)[1]).ToString() + ", " +
					"z: " + Mathf.Round(MoverioController.Instance.GetSensorData(TYPE_CONTROLLER_ACCELEROMETER)[2]).ToString();

			TextView1.text = "CONTROLLER MAG x: " + Mathf.Round(MoverioController.Instance.GetSensorData(TYPE_CONTROLLER_MAGNETIC_FIELD)[0]).ToString() + ", " +
				"y: " + Mathf.Round(MoverioController.Instance.GetSensorData(TYPE_CONTROLLER_MAGNETIC_FIELD)[1]).ToString() + ", " +
					"z: " + Mathf.Round(MoverioController.Instance.GetSensorData(TYPE_CONTROLLER_MAGNETIC_FIELD)[2]).ToString();

			TextView2.text = "CONTROLLER GYRO x: " + Mathf.Round(MoverioController.Instance.GetSensorData(TYPE_CONTROLLER_GYROSCOPE)[0]).ToString() + ", " +
				"y: " + Mathf.Round(MoverioController.Instance.GetSensorData(TYPE_CONTROLLER_GYROSCOPE)[1]).ToString() + ", " +
					"z: " + Mathf.Round(MoverioController.Instance.GetSensorData(TYPE_CONTROLLER_GYROSCOPE)[2]).ToString();

			TextView3.text = "CONTROLLER ROTAT x: " + (MoverioController.Instance.GetSensorData(TYPE_CONTROLLER_ROTATION_VECTOR)[1] * 180f).ToString() + ", " +
				"y: " + (MoverioController.Instance.GetSensorData(TYPE_CONTROLLER_ROTATION_VECTOR)[2] * 180f).ToString() + ", " +
					"z: " + (-MoverioController.Instance.GetSensorData(TYPE_CONTROLLER_ROTATION_VECTOR)[0] * 180f).ToString();

			TextView4.text = "";

		}
        else
        {
			TextView0.text = "HEADSET ACCEL x: " + Mathf.Round(MoverioController.Instance.GetSensorData(TYPE_HEADSET_ACCELEROMETER)[0]).ToString() + ", " +
			"y: " + Mathf.Round(MoverioController.Instance.GetSensorData(TYPE_HEADSET_ACCELEROMETER)[1]).ToString() + ", " +
				"z: " + Mathf.Round(MoverioController.Instance.GetSensorData(TYPE_HEADSET_ACCELEROMETER)[2]).ToString();

			TextView1.text = "HEADSET MAG x: " + Mathf.Round(Input.compass.rawVector.x).ToString() + 
				", y: " + Mathf.Round(Input.compass.rawVector.y).ToString() + 
				", z: " + Mathf.Round(Input.compass.rawVector.z).ToString();

			TextView2.text = "HEADSET GYRO x: "  + Input.gyro.rotationRateUnbiased.x.ToString()  + 
				", y: " + Input.gyro.rotationRateUnbiased.y.ToString() + 
				", z: " + Input.gyro.rotationRateUnbiased.z.ToString();

			TextView3.text = ""; 

			TextView4.text = "HEADSET TAP: " + MoverioController.Instance.GetHeadsetTap().ToString() + ", Tap Count: " + MoverioController.Instance.GetHeadsetTapCount().ToString();

		}




	}
	void Update()
	{ 
		Debug.Log(toggle.isOn);
		DisplaySensorData();
	}

	//The following sequence will step through various display functions. 
	//It will then show the various sensor data values. 

	//IEnumerator TutorialSequence()
	//{

		/*yield return new WaitForSeconds(3.0f);

		TextView5.text = "Starting Dimmer";

		yield return new WaitForSeconds(3.0f);

		MoverioController.Instance.SetDisplayBrightness(10);
		
		TextView5.text = "Brightness at 10!";


		yield return new WaitForSeconds(3.0f);

		MoverioController.Instance.SetDisplayBrightness(5);
		
		TextView5.text = "Brightness at 5!";

		yield return new WaitForSeconds(3.0f);

		MoverioController.Instance.SetDisplayBrightness(15);
		
		TextView5.text = "Brightness at 15!";

		yield return new WaitForSeconds(3.0f);

		MoverioController.Instance.SetDisplayBrightness(20);
		
		TextView5.text = "Brightness at 20!";

		yield return new WaitForSeconds(2.0f);
		
		MoverioController.Instance.SetDisplay3D(true);
		
		TextView5.text = "3D Mode on!";

		yield return new WaitForSeconds(3.0f);
		
		MoverioController.Instance.SetDisplay3D(false);
		
		TextView5.text = "3D Mode off!";

		yield return new WaitForSeconds (3.0f);

		TextView5.text = "Muting Display";

		yield return new WaitForSeconds (2.0f);

		MoverioController.Instance.MuteDisplay(true);

		yield return new WaitForSeconds (3.0f);

		MoverioController.Instance.MuteDisplay (false); 

		TextView5.text = "Mute Display Off";

		yield return new WaitForSeconds(3.0f);

		for ( int i = 0; i< 250; i++)
		{
			DisplaySensorData();
			yield return new WaitForSeconds(0.1f);
		}
		TextView.text = "";
		TextView2.text = "";
		TextView3.text = "";
		TextView4.text = "";
		TextView5.text = "End of Sensor Demo";
		TextView6.text = "";

	}*/


}
