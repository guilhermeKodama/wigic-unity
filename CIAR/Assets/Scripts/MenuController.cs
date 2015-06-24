using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickStartButton(){
		Application.LoadLevel("Main");
	}

	public void onClickDownloadTargets(){
		Application.OpenURL ("http://unity3d.com/");
	}
}
