using UnityEngine;
using System.Collections;
using Vuforia;

public class UnderwaterController : MonoBehaviour, ITrackableEventHandler {

	public GameObject terrain;
	private TrackableBehaviour trackable;

	void Start () {
		trackable = (TrackableBehaviour)UnityEngine.Object.FindObjectOfType(typeof(TrackableBehaviour));
		trackable.RegisterTrackableEventHandler(this);
	}


	public void OnTrackableStateChanged (TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {

		Debug.Log ("PREVIOUS: " + previousStatus + " - " + "NEW: " + newStatus);

		if (previousStatus == TrackableBehaviour.Status.UNKNOWN || previousStatus == TrackableBehaviour.Status.NOT_FOUND && newStatus == TrackableBehaviour.Status.NOT_FOUND || newStatus == TrackableBehaviour.Status.UNKNOWN ) {
		
			terrain.gameObject.SetActive(false);

		}

		if (newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			
			terrain.gameObject.SetActive(true);
			
		}

	}
}
