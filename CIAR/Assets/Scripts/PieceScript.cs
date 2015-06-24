using UnityEngine;
using System.Collections;

public class PieceScript : MonoBehaviour {

	private int size;
	private int line;
	private int column;
	private float proximity;
	private bool left, right, back, forward;

	public GameObject text;

	// Use this for initialization
	void Start () {

		TextMesh texto = text.gameObject.GetComponent<TextMesh> ();
		texto.text = getLine () + "-" + getColumn ();

	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;

		if (line == 1) {
			forward = true;
		} else {
		
			if (Physics.Raycast (new Ray (transform.position, Vector3.forward), out hit, getProximity())) {
				
				if (hit.collider.tag == "Piece") {
					PieceScript piece = hit.collider.gameObject.GetComponent<PieceScript> ();
					
					if (getColumn() == piece.getColumn() && (getLine() - piece.getLine()== 1) ) {
						Debug.DrawRay (transform.position, Vector3.forward * proximity, Color.red);
						forward = true;
					} else {
						forward = false;
					}
					
				}
			} else {
				forward = false;
			}
		}

		if (line == size) {
			back = true;
		} else {
		
			if (Physics.Raycast (new Ray (transform.position, Vector3.back), out hit, getProximity())) {
				if (hit.collider.tag == "Piece") {
					PieceScript piece = hit.collider.gameObject.GetComponent<PieceScript> ();
					
					if (getColumn() == piece.getColumn() && (piece.getLine() - getLine() == 1) ) {
						Debug.DrawRay (transform.position, Vector3.back * proximity, Color.red);
						back = true;
					} else {
						back = false;
					}
				}
			} else {
				back = false;
			}
		}

		if (column == 1) {
			left = true;
		} else {
		
			if (Physics.Raycast (new Ray (transform.position, Vector3.left), out hit, getProximity())) {
				
				if (hit.collider.tag == "Piece") {
					PieceScript piece = hit.collider.gameObject.GetComponent<PieceScript> ();
					
					if (getLine() == piece.getLine() && (getColumn() - piece.getColumn() == 1)) {
						Debug.DrawRay (transform.position, Vector3.left * proximity, Color.red);
						left = true;
					} else {
						left = false;
					}
				}
			} else {
				left = false;
			}
		}

		if (column == size) {
			right = true;
		} else {
		
			if (Physics.Raycast (new Ray (transform.position, Vector3.right), out hit, getProximity())) {
				
				if (hit.collider.tag == "Piece") {
					PieceScript piece = hit.collider.gameObject.GetComponent<PieceScript> ();
					
					if (getLine() == piece.getLine() && (piece.getColumn() - getColumn() == 1)) {
						Debug.DrawRay (transform.position, Vector3.right * proximity, Color.red);
						right = true;
					} else {
						right = false;
					}
					
				}
			} else {
				right = false;
			}
		}

		if (isDone()) {
			gameObject.GetComponent<MeshRenderer> ().material.color = Color.green;

		} else {
			gameObject.GetComponent<MeshRenderer> ().material.color = Color.red;
		}

	}

	public bool isDone () {

		if (right && left && back && forward) {
			return true;
		}
		return false;
	} 

	public void setLine (int line) {
		this.line = line;
	}

	public int getLine () {
		return line;
	}

	public void setColumn (int column) {
		this.column = column;
	}
	
	public int getColumn () {
		return column;
	}

	public void setSize (int size) {
		this.size = size;
	}
	
	public int getSize () {
		return size;
	}

	public void setProximity (float Proximity) {
		this.proximity = proximity;
	}
	
	public float getProximity () {
		return proximity;
	}

}