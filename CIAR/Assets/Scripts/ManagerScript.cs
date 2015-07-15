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
	public GameObject settingsSelector;
	private bool menuIsMoving = false;
	private bool menuUp = false;
	private bool settingsWasClicked = false;
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

	private Vector3 backgroundPosition;
	private Vector3 butterflyPosition;
	private Vector3 horsePosition;
	private Vector3 whalePosition;
	private Vector3 animalSelectorPosition;
	private Vector3 settingsSelectorPosition;


	public void Start () {
		menuSelector.SetActive (false);
		CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
		takeScreenshot = false;

	}

	public void Update () {

		backgroundPosition = background.GetComponent<RectTransform>().anchoredPosition3D;
		butterflyPosition = butterfly.GetComponent<RectTransform>().anchoredPosition3D;
		horsePosition = horse.GetComponent<RectTransform>().anchoredPosition3D;
		whalePosition = whale.GetComponent<RectTransform>().anchoredPosition3D;
		animalSelectorPosition = animalSelector.GetComponent<RectTransform>().anchoredPosition3D;
		settingsSelectorPosition = settingsSelector.GetComponent<RectTransform> ().anchoredPosition3D;

		if (menuIsMoving) {
			if (menuUp) {

				background.GetComponent<RectTransform>().anchoredPosition3D = Vector3.Lerp (backgroundPosition, new Vector3 (backgroundPosition.x, 1036f, backgroundPosition.z), 0.1f);
				butterfly.GetComponent<RectTransform>().anchoredPosition3D = Vector3.Lerp(butterflyPosition, new Vector3 (butterflyPosition.x, 490f, butterflyPosition.z), 0.1f);
				horse.GetComponent<RectTransform>().anchoredPosition3D = Vector3.Lerp(horsePosition, new Vector3 (horsePosition.x, 720f, horsePosition.z), 0.1f);
				whale.GetComponent<RectTransform>().anchoredPosition3D = Vector3.Lerp(whalePosition, new Vector3 (whalePosition.x, 950f, whalePosition.z), 0.1f);
				animalSelector.GetComponent<RectTransform>().anchoredPosition3D = Vector3.Lerp(animalSelectorPosition, new Vector3 (animalSelectorPosition.x, 720f, animalSelectorPosition.z), 0.1f);
				menuSelector.SetActive(true);

			} else {

				background.GetComponent<RectTransform>().anchoredPosition3D = Vector3.Lerp (backgroundPosition, new Vector3 (backgroundPosition.x, 0f, backgroundPosition.z), 0.1f);
				butterfly.GetComponent<RectTransform>().anchoredPosition3D = Vector3.Lerp(butterflyPosition, new Vector3 (butterflyPosition.x, -500f, butterflyPosition.z), 0.1f);
				horse.GetComponent<RectTransform>().anchoredPosition3D = Vector3.Lerp(horsePosition, new Vector3 (horsePosition.x, -250f, horsePosition.z), 0.1f);
				whale.GetComponent<RectTransform>().anchoredPosition3D = Vector3.Lerp(whalePosition, new Vector3 (whalePosition.x, 0f, whalePosition.z), 0.1f);
				animalSelector.GetComponent<RectTransform>().anchoredPosition3D = Vector3.Lerp(animalSelectorPosition, new Vector3 (animalSelectorPosition.x, -250f, animalSelectorPosition.z), 0.1f);
				menuSelector.SetActive(false);

			}
		}

		if (settingsWasClicked) {
			settingsSelector.GetComponent<RectTransform> ().anchoredPosition3D = Vector3.Lerp (settingsSelectorPosition, new Vector3 (-520f, -520f, settingsSelectorPosition.z), 0.1f);
		} else {
			settingsSelector.GetComponent<RectTransform> ().anchoredPosition3D = Vector3.Lerp (settingsSelectorPosition, new Vector3 (-100f, -100f, settingsSelectorPosition.z), 0.1f);
		}

		if (whaleWasClicked && menuUp) {
			animalSelector.GetComponent<RectTransform>().anchoredPosition3D = Vector3.Lerp(animalSelectorPosition, new Vector3(whalePosition.x, whalePosition.y, animalSelectorPosition.z), 0.2f);
		}

		if (horseWasClicked && menuUp) {
			animalSelector.GetComponent<RectTransform>().anchoredPosition3D = Vector3.Lerp(animalSelectorPosition, new Vector3(horsePosition.x, horsePosition.y, animalSelectorPosition.z), 0.2f);
		}

		if (butterflyWasClicked && menuUp) {
			animalSelector.GetComponent<RectTransform>().anchoredPosition3D = Vector3.Lerp(animalSelectorPosition, new Vector3(butterflyPosition.x, butterflyPosition.y, animalSelectorPosition.z), 0.2f);
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

	public void onClickDownload(){
		Application.OpenURL ("http://www.wigic.io/");
	}

	public void onClickMenu(){
		menuUp = !menuUp;
		menuIsMoving = true;
	}

	/*MENU ITEM CLICK*/
	
	public void onClickSettings(){
		settingsWasClicked = !settingsWasClicked;
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

	public void OnSwipeDown() {
		if (menuUp) {
			menuUp = !menuUp;
			menuIsMoving = true;
		}
	}

}
