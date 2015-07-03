using UnityEngine;
using System.Collections;
using Vuforia;

public class ManagerScript : MonoBehaviour {
	
	public GameObject cameraButton;
	public GameObject switchCameremaButton;
	private bool takeScreenshot;
	private CameraDevice.CameraDirection direction = CameraDevice.CameraDirection.CAMERA_BACK;
	

	/*Menu*/
	public Canvas canvas;
	public GameObject backgroundMenu;
	public GameObject whale;
	public GameObject horse;
	public GameObject butterfly;
	public GameObject menuSelector;
	public bool menuIsMoving = false;
	public bool menuUp = false;
	/*Selector*/
	public bool whaleWasClicked = false;
	public bool horseWasClicked = false;
	public bool butterflyWasClicked = false;
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
		CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
		takeScreenshot = false;

	}
	
	public void Update () {
		if (menuIsMoving) {
			if (menuUp) {
				backgroundMenu.transform.position = Vector3.Lerp (backgroundMenu.transform.position,
			                                                 new Vector3 (backgroundMenu.transform.position.x, (float)(canvas.transform.position.y * 0.85), backgroundMenu.transform.position.z),
			  		                                          0.1F);

				butterfly.transform.position = Vector3.Lerp(butterfly.transform.position,
				                                            new Vector3 (canvas.transform.position.x,butterfly.transform.position.y, butterfly.transform.position.z),
				                                            0.1F);
				horse.transform.position = Vector3.Lerp(horse.transform.position,
				                                        new Vector3 (canvas.transform.position.x,horse.transform.position.y, horse.transform.position.z),
				                                        	0.08F);
				whale.transform.position = Vector3.Lerp(whale.transform.position,
				                                        new Vector3 (canvas.transform.position.x,whale.transform.position.y, whale.transform.position.z),
				                                            0.07F);

				menuSelector.transform.position = Vector3.Lerp(menuSelector.transform.position,
				                                               new Vector3 (canvas.transform.position.x,menuSelector.transform.position.y, menuSelector.transform.position.z),
				                                        0.07F);

			}else{
				backgroundMenu.transform.position = Vector3.Lerp (backgroundMenu.transform.position,
				                                                  new Vector3 (backgroundMenu.transform.position.x, (float)(canvas.transform.position.y * 0.7) * -1, backgroundMenu.transform.position.z
				             ),
				                                                  0.1F);

				butterfly.transform.position = Vector3.Lerp(butterfly.transform.position,
				                                            new Vector3 ((float)(canvas.transform.position.x * 2.5 ),butterfly.transform.position.y, butterfly.transform.position.z),
				                                            0.1F);
				horse.transform.position = Vector3.Lerp(horse.transform.position,
				                                        new Vector3 ((float)(canvas.transform.position.x * 2.5 ),horse.transform.position.y, horse.transform.position.z),
				                                        0.1F);
				whale.transform.position = Vector3.Lerp(whale.transform.position,
				                                        new Vector3 ((float)(canvas.transform.position.x * 2.5 ),whale.transform.position.y, whale.transform.position.z),
				                                        0.1F);

				menuSelector.transform.position = Vector3.Lerp(menuSelector.transform.position,
				                                               new Vector3 ((float)(canvas.transform.position.x * 4.6 ),menuSelector.transform.position.y, menuSelector.transform.position.z),
				                                               0.07F);
			}
		}

		if (whaleWasClicked) {
			menuSelector.transform.position = Vector3.Lerp(menuSelector.transform.position,
			                                               whale.transform.position,
			                                               0.2F);
		}

		if (horseWasClicked) {
			menuSelector.transform.position = Vector3.Lerp(menuSelector.transform.position,
			                                               horse.transform.position,
			                                               0.2F);
		}

		if (butterflyWasClicked) {
			menuSelector.transform.position = Vector3.Lerp(menuSelector.transform.position,
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
		switchCameremaButton.SetActive (false);
		Application.CaptureScreenshot ("Screenshot.jpeg", 4);
		cameraButton.SetActive (true);
		switchCameremaButton.SetActive (true);
		setTakeScreenshot (false);
		CameraDevice.Instance.Stop ();
		CameraDevice.Instance.Start ();
		//CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
		
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

	public void dowloadTargets(){
		Application.OpenURL ("http://173.255.205.14/wigic/");
	}

	public void showMenu(){
		Debug.Log ("VOU MOSTRAR O MENU");
		//menuPopUp.SetActive (!menuPopUp.activeSelf);

		menuUp = !menuUp;
		menuIsMoving = true;

		/*piece1.GetComponent<MeshRenderer> ().material.color = Color.red;
		piece2.GetComponent<MeshRenderer> ().material.color = Color.red;
		piece3.GetComponent<MeshRenderer> ().material.color = Color.red;
		piece7.GetComponent<MeshRenderer> ().material.color = Color.red;
		piece8.GetComponent<MeshRenderer> ().material.color = Color.red;
		piece9.GetComponent<MeshRenderer> ().material.color = Color.red;
		piece1.GetComponent<MeshRenderer>().material = red;
		piece2.GetComponent<MeshRenderer>().material = red;
		piece3.GetComponent<MeshRenderer>().material = red;
		piece7.GetComponent<MeshRenderer>().material = red;
		piece8.GetComponent<MeshRenderer>().material = red;
		piece9.GetComponent<MeshRenderer>().material = red;*/
	}

	/*MENU ITEM CLICK*/

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
