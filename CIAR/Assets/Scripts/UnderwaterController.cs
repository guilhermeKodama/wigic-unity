using UnityEngine;
using System.Collections;
using Vuforia;

public class UnderwaterController : MonoBehaviour, ITrackableEventHandler {
	

	public GameObject terrain;
	private TrackableBehaviour trackable;

	/*Criar sensação de estar debaixo dagua*/
	private Color normalColor;
	private Color underwaterColor;

	void Start () {
		/*Underwater Effect*/
		normalColor = new Color (0.5f,0.5f,0.5f);
		underwaterColor = new Color (0.22f,0.65f,0.77f,0.5f);

		trackable = (TrackableBehaviour)UnityEngine.Object.FindObjectOfType(typeof(TrackableBehaviour));
		trackable.RegisterTrackableEventHandler(this);
	}


	public void OnTrackableStateChanged (TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {

		Debug.Log ("PREVIOUS: " + previousStatus + " - " + "NEW: " + newStatus);

		if (previousStatus == TrackableBehaviour.Status.TRACKED && newStatus == TrackableBehaviour.Status.NOT_FOUND ||  previousStatus == TrackableBehaviour.Status.EXTENDED_TRACKED && newStatus == TrackableBehaviour.Status.NOT_FOUND) {
			
			terrain.gameObject.SetActive(false);
			RenderSettings.fog = false;
			RenderSettings.fogColor = normalColor;
			RenderSettings.fogDensity = 0;

		}

		if (newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			
			terrain.gameObject.SetActive(true);
			RenderSettings.fog = true;
			RenderSettings.fogColor = underwaterColor;
			RenderSettings.fogDensity = 0.03f;
			
		}

	}
}
