using UnityEngine;
using System.Collections;

public class UnderWater : MonoBehaviour {
	
	private Color normalColor;
	private Color underwaterColor;

	// Use this for initialization
	void Start () {
		normalColor = new Color (0.5f,0.5f,0.5f);
		underwaterColor = new Color (0.22f,0.65f,0.77f,0.5f);
		RenderSettings.fog = true;
	}
	
	// Update is called once per frame
	void Update () {
		SetUnderwater ();
	}

	void SetUnderwater(){
		RenderSettings.fogColor = underwaterColor;
		RenderSettings.fogDensity = 0.03f;
	}
}


