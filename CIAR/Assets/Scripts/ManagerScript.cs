using UnityEngine;
using System.Collections;
using Vuforia;

public class ManagerScript : MonoBehaviour {
	
	public GameObject cameraButton;
	public GameObject switchCameremaButton;
	private bool takeScreenshot;
	private CameraDevice.CameraDirection direction = CameraDevice.CameraDirection.CAMERA_BACK;

	public void Start () {

		takeScreenshot = false;

	}
	
	public void Update () {

	}
	
	public void LateUpdate () {
		
		if (takeScreenshot) {
			takePicture();
		}
		
	}
	
	public void setTakeScreenshot (bool status) {
		takeScreenshot = status;
	}
	
	public void takePicture () {
		Debug.Log ("Taking Picture");
		cameraButton.SetActive (false);
		switchCameremaButton.SetActive (false);
		Application.CaptureScreenshot ("Screenshot.jpeg", 4);
		cameraButton.SetActive (true);
		switchCameremaButton.SetActive (true);
		setTakeScreenshot (false);
		CameraDevice.Instance.Stop ();
		CameraDevice.Instance.Start ();
		//		CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
		
	}
	
	public void switchCamera () {
		if (direction == CameraDevice.CameraDirection.CAMERA_BACK) {
			CameraDevice.Instance.Stop ();
			CameraDevice.Instance.Init (CameraDevice.CameraDirection.CAMERA_FRONT);
			CameraDevice.Instance.Start ();
			direction = CameraDevice.CameraDirection.CAMERA_FRONT;
		} else {
			CameraDevice.Instance.Stop ();
			CameraDevice.Instance.Init (CameraDevice.CameraDirection.CAMERA_BACK);
			CameraDevice.Instance.Start ();
			direction = CameraDevice.CameraDirection.CAMERA_BACK;
		}
	}
}
