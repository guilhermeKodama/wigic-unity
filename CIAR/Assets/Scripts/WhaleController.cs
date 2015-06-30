using UnityEngine;
using System.Collections;

public class WhaleController : MonoBehaviour {
	

	private Rigidbody rb;
	private NavMeshAgent nav;
	public float tumble;

	public GameObject meshChild;




	/*MOVEMENT*/
	private float speed;
	private float maxSpeed;
	private float acceleration;
	/*MOVIMENTO DE DESLOCAMENTO*/
	public float whaleWaveMovementAngle;
	private float whaleWaveDirection;
	private float whaleWaveMovementSpeed;
	/*MOVEMENT POSITIONS*/
	public Transform[] points;
	private int destPoint = 0;
	
	void Start(){
		speed = 1F;
		maxSpeed = 2F;
		acceleration = 1.01F;

		whaleWaveMovementAngle = 0;
		whaleWaveDirection = 1F;
		whaleWaveMovementSpeed = 0.04F;


		GotoNextPoint();
	}

	void GotoNextPoint(){
		// Returns if no points have been set up
		if (points.Length == 0)
			return;

		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = (destPoint + 1) % points.Length;

	}

	void Swim(){
		Transform cube = points[destPoint];
		

		Vector3 cubePosition = new Vector3 (cube.position.x, cube.position.y, cube.position.z);
		
		
		/* Anguling whale movement
		Debug.Log(Vector3.Angle (transform.position, cube.transform.position));
			

		if (whaleWaveMovementAngle >= 5 || whaleWaveMovementAngle <= -5) {
			whaleWaveDirection *= -1F;
		}	

		whaleWaveMovementAngle = whaleWaveMovementAngle + (whaleWaveMovementSpeed * whaleWaveDirection) ;
		cubePosition = new Vector3 (cube.position.x, cube.position.y + whaleWaveMovementAngle, cube.position.z);
		*/
		
		
		// Direccion: definimos el vector direccion hacia el cual nos vamos a mover (restamos posicion objetivo - posicion nuestra)
		Vector3 direccion = cubePosition - transform.position;
		// Movimiento:_Son "nuevas posiciones" cada vez mas cercanas al objetivo.
		// normalizar el vector es como obtener en lugar de toda la ruta, en que direccion tiene que dar "cada pequeño paso"
		// al multiplicar por la velocidad, determinamos que tan "largo" es ese paso.
		// usamos time.deltatime para que tenga un movimiento smooth respecto de los frames.
		
		/*if (speed < maxSpeed) {
			speed *= acceleration;
		}*/
		
		Vector3 movimento = direccion.normalized * speed * Time.deltaTime;
		
		transform.LookAt(cubePosition);
		transform.position = transform.position + movimento;
	}

	void Update(){

//		Debug.Log (Vector3.Distance(transform.position,points[destPoint].position));

		// Choose the next destination point when the agent gets
		// close to the current one.
		if (Vector3.Distance(transform.position,points[destPoint].position) < 1F) {
			GotoNextPoint ();
		}

		Swim ();

			
	}

}
