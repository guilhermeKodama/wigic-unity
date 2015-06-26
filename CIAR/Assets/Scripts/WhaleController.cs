using UnityEngine;
using System.Collections;

public class WhaleController : MonoBehaviour {

	private Transform cube;

	private Rigidbody rb;
	private NavMeshAgent nav;
	public float speed;
	public float tumble;

	public GameObject meshChild;

	public Transform[] points;
	private int destPoint = 0;



	void Start(){
		rb = GetComponent<Rigidbody> ();
		nav = GetComponent<NavMeshAgent> ();
		nav.autoBraking = false;

		cube = GameObject.FindGameObjectWithTag ("Cube").transform;

		GotoNextPoint();
	}

	void GotoNextPoint(){
		// Returns if no points have been set up
		if (points.Length == 0)
			return;
		
		// Set the agent to go to the currently selected destination.
		nav.destination = points[destPoint].position;
		
		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = (destPoint + 1) % points.Length;
	}

	void Update(){

		// Choose the next destination point when the agent gets
		// close to the current one.
		if (nav.remainingDistance < 2.5f) {
			GotoNextPoint();
		}
			
	}
	

	void FixedUpdate(){

		/*Input*
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);

		rb.AddForce (movement);*/

		/*Rotation*/
		//transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);

		/*AI Movement*/

	}
}
