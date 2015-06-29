using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WigManagerScript : MonoBehaviour {

	public GameObject[] wigsObj;
	public GameObject currtenWig;

	private GameObject wig;
	private ArrayList wigs;
	private int index;
	private bool slid;

	void Start () {
		index = 0;
		wigs = new ArrayList (wigsObj);
		wig = wigs [index] as GameObject;
		currtenWig.gameObject.GetComponent<SpriteRenderer>().sprite =  wig.gameObject.GetComponent<SpriteRenderer>().sprite;
	}

	void Update () {

	}

	void OnSwipeLeft () {
		if (index == 0) {
			index = wigs.Count - 1;
		} else {
			index--;
		}
		wig = wigs [index] as GameObject;
		currtenWig.gameObject.GetComponent<SpriteRenderer> ().sprite = wig.gameObject.GetComponent<SpriteRenderer> ().sprite;
	}

	void OnSwipeRight () {
		if (index == wigs.Count - 1) {
			index = 0;
		} else {
			index++;
		}
		wig = wigs [index] as GameObject;
		currtenWig.gameObject.GetComponent<SpriteRenderer> ().sprite = wig.gameObject.GetComponent<SpriteRenderer> ().sprite;
	}

}
