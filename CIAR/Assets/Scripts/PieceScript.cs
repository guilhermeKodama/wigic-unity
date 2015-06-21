using UnityEngine;
using System.Collections;

public class PieceScript : MonoBehaviour {
	
	public float raySize = 300f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		RaycastHit hit;

		Debug.DrawRay (transform.position, Vector3.right * raySize, Color.red);
		Debug.DrawRay (transform.position, Vector3.left * raySize, Color.red);
		Debug.DrawRay (transform.position, Vector3.back * raySize, Color.red);
		Debug.DrawRay (transform.position, Vector3.forward * raySize, Color.red);

		if (Physics.Raycast (new Ray (transform.position, Vector3.left), out hit, raySize) || 
			Physics.Raycast (new Ray (transform.position, Vector3.right), out hit, raySize) || 
			Physics.Raycast (new Ray (transform.position, Vector3.back), out hit, raySize) || 
			Physics.Raycast (new Ray (transform.position, Vector3.forward), out hit, raySize)) {

			Debug.Log ("Contato!");

			if (hit.collider.tag == "Piece") {

				Debug.Log ("Piece!");

				gameObject.GetComponent<MeshRenderer> ().material.color = Color.green;
			}
		} else {
		
			gameObject.GetComponent<MeshRenderer> ().material.color = Color.gray;

		}

	}
}