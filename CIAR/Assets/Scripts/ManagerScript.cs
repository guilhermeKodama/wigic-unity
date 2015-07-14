using UnityEngine;
using System.Collections;
using Vuforia;

public class ManagerScript : MonoBehaviour {
	
	public GameObject cameraButton;
	public GameObject switchButton;
	private bool takeScreenshot;
	private CameraDevice.CameraDirection direction = CameraDevice.CameraDirection.CAMERA_BACK;
	

	/*Menu*/
	public Canvas canvas;
	public GameObject background;
	public GameObject whale;
	public GameObject horse;
	public GameObject butterfly;
	public GameObject animalSelector;
	public GameObject menuSelector;
	private bool menuIsMoving = false;
	private bool menuUp = false;
	/*Selector*/
	private bool whaleWasClicked = false;
	private bool horseWasClicked = false;
	private bool butterflyWasClicked = false;
	/*Change sprite render*/
	public GameObject piece;
	public GameObject spriteWhale;
	public GameObject spriteHorse;
	public GameObject spriteButterfly;
	/*3D objects*/
	public GameObject whale3D;
	public GameObject horse3D;
	public GameObject butterfly3D;


	public void Start () {

		/*if ((UnityEngine.iOS.Device.generation.ToString ()).IndexOf ("iPad") > -1) {
			Debug.Log ("+++++++++++++++++++IS IPAD");
		} else {
			Debug.Log ("+++++++++++++++++++IS IPHONE");
		}*/
		menuSelector.SetActive (false);
		CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
		takeScreenshot = false;

	}
	
	public void Update () {
		if (menuIsMoving) {
			if (menuUp) {
				background.GetComponent<RectTransform>().localPosition = Vector3.Lerp (background.transform.localPosition,
			                                                 new Vector3 (background.transform.localPosition.x, (float)(canvas.transform.position.y * 0.1) * -1, background.transform.localPosition.z),
			  		                                          0.1F);

				butterfly.transform.localPosition = Vector3.Lerp(butterfly.transform.localPosition,
				                                            new Vector3 (butterfly.transform.localPosition.x, -40f, butterfly.transform.localPosition.z),
				                                            0.1F);
				horse.transform.localPosition = Vector3.Lerp(horse.transform.position,
				                                        new Vector3 (horse.transform.localPosition.x, -40f, horse.transform.localPosition.z),
				                                        	0.1F);
				whale.transform.localPosition = Vector3.Lerp(whale.transform.position,
				                                        new Vector3 (whale.transform.localPosition.x, -40f, whale.transform.localPosition.z),
				                                            0.1F);

				animalSelector.transform.localPosition = Vector3.Lerp(animalSelector.transform.localPosition,
				                                               new Vector3 (animalSelector.transform.localPosition.x, -40f, animalSelector.transform.localPosition.z),
				                                        0.08F);

			} else {
				background.GetComponent<RectTransform>().localPosition = Vector3.Lerp (background.transform.localPosition,
				                                                  new Vector3 (background.transform.localPosition.x, (float)(canvas.transform.position.y * 0.7), background.transform.localPosition.z
				             ),
				                                                  0.1F);

				butterfly.transform.localPosition = Vector3.Lerp(butterfly.transform.position,
				                                            new Vector3 (butterfly.transform.localPosition.x, (float)(canvas.transform.position.y * 2.5 ), butterfly.transform.localPosition.z),
				                                            0.1F);
				horse.transform.localPosition = Vector3.Lerp(horse.transform.localPosition,
				                                             new Vector3 (horse.transform.localPosition.x, (float)(canvas.transform.position.y * 2.5 ), horse.transform.localPosition.z),
				                                        0.1F);
				whale.transform.localPosition = Vector3.Lerp(whale.transform.position,
				                                        new Vector3 (whale.transform.localPosition.x, (float)(canvas.transform.position.y * 2.5 ), whale.transform.localPosition.z),
				                                        0.1F);

				animalSelector.transform.localPosition = Vector3.Lerp(animalSelector.transform.localPosition,
				                                               new Vector3 (animalSelector.transform.localPosition.x, (float)(canvas.transform.position.y * 4.6 ), animalSelector.transform.localPosition.z),
				                                               0.08F);

			}
		}

		if (whaleWasClicked) {
			animalSelector.transform.localPosition = Vector3.Lerp(animalSelector.transform.localPosition,
			                                               whale.transform.localPosition,
			                                               0.2F);
		}

		if (horseWasClicked) {
			animalSelector.transform.localPosition = Vector3.Lerp(animalSelector.transform.localPosition,
			                                                      horse.transform.localPosition,
			                                               0.2F);
		}

		if (butterflyWasClicked) {
			animalSelector.transform.localPosition = Vector3.Lerp(animalSelector.transform.position,
			                                               butterfly.transform.position,
			                                               0.2F);
		}
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
		switchButton.SetActive (false);
		Application.CaptureScreenshot ("Screenshot.jpeg", 4);
		cameraButton.SetActive (true);
		switchButton.SetActive (true);
		setTakeScreenshot (false);
		CameraDevice.Instance.Stop ();
		CameraDevice.Instance.Start ();
		//CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
		
	}
	
	public void switchCamera () {
		if (direction == CameraDevice.CameraDirection.CAMERA_BACK) {
			CameraDevice.Instance.Stop ();
			CameraDevice.Instance.Deinit();
			TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
			CameraDevice.Instance.Init (CameraDevice.CameraDirection.CAMERA_FRONT);
			CameraDevice.Instance.Start ();
			TrackerManager.Instance.GetTracker<ObjectTracker>().Start();
			direction = CameraDevice.CameraDirection.CAMERA_FRONT;
		} else {
			CameraDevice.Instance.Stop ();
			CameraDevice.Instance.Deinit();
			TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
			CameraDevice.Instance.Init (CameraDevice.CameraDirection.CAMERA_BACK);
			CameraDevice.Instance.Start ();
			TrackerManager.Instance.GetTracker<ObjectTracker>().Start();
			direction = CameraDevice.CameraDirection.CAMERA_BACK;
		}
	}

	public void dowloadTargets(){
		Application.OpenURL ("http://173.255.205.14/wigic/");
	}

	public void onClickMenu(){
		Debug.Log ("VOU MOSTRAR O MENU");
		//menuPopUp.SetActive (!menuPopUp.activeSelf);
		menuUp = !menuUp;
		menuIsMoving = true;
		menuSelector.SetActive(true);
	}

	/*MENU ITEM CLICK*/
	
	public void onClickOptions(){
		Debug.Log ("OnClickOptions");
	}

	public void onClickWhale(){
		whaleWasClicked = true;
		horseWasClicked = false;
		butterflyWasClicked = false;
		piece.GetComponent<SpriteRenderer> ().sprite = spriteWhale.GetComponent<SpriteRenderer>().sprite;

		whale3D.SetActive (true);
		horse3D.SetActive (false);
		butterfly3D.SetActive (false);
	}

	public void onClickHorse(){
		horseWasClicked = true;
		butterflyWasClicked = false;
		whaleWasClicked = false;
		piece.GetComponent<SpriteRenderer> ().sprite = spriteHorse.GetComponent<SpriteRenderer>().sprite;

		whale3D.SetActive (false);
		horse3D.SetActive (true);
		butterfly3D.SetActive (false);
	}

	public void onClickButterfly(){
		butterflyWasClicked = true;
		horseWasClicked = false;
		whaleWasClicked = false;
		piece.GetComponent<SpriteRenderer> ().sprite = spriteButterfly.GetComponent<SpriteRenderer>().sprite;

		whale3D.SetActive (false);
		horse3D.SetActive (false);
		butterfly3D.SetActive (true);
	}


}
