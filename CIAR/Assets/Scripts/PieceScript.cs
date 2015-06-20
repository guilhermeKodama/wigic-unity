using UnityEngine;
using System.Collections;

public class PieceScript : MonoBehaviour {
	
	public float raySize = 300f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		Debug.DrawRay (transform.position, Vector3.right * raySize);

	}
}
