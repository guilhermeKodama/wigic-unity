using UnityEngine;
using System.Collections;

public class PuzzleManagerScript : MonoBehaviour {

	public float proximity;
	public int totalPieces;
	public GameObject[] piecesObj;
	public GameObject[] horseObj;

	private ArrayList pieces;
	private ArrayList positions;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < horseObj.Length; i++) {

			piecesObj[i].gameObject.GetComponent<SpriteRenderer>().sprite = horseObj[i].gameObject.GetComponent<SpriteRenderer>().sprite;
			
		}

		pieces = new ArrayList (piecesObj);
		initiPieces ();
		buildMatrixPositions ();
		positions =  shufflePositions (positions);
		linkingPiecesAndPositions ();
	}
	
	// Update is called once per frame
	void Update () {

		foreach (GameObject pieceObj in pieces) {
			PieceScript piece = pieceObj.gameObject.GetComponent<PieceScript>();
			if (piece.isDone()) {
				Debug.Log("VENCEU!!!");
			} else {
				Debug.Log("AINDA NÃO!!!");
			}
		}

	}

	private void initiPieces () {
		foreach (GameObject pieceObj in pieces) {
			PieceScript piece = pieceObj.gameObject.GetComponent<PieceScript>();
			piece.setSize(totalPieces);
			piece.setProximity(proximity);
		}
	}

	private ArrayList shufflePositions (ArrayList inputList) {

		ArrayList randomList = new ArrayList();

		System.Random r = new System.Random();
		int randomIndex = 0;
		while (inputList.Count > 0)
		{
			randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
			randomList.Add(inputList[randomIndex]); //add it to the new, random list
			inputList.RemoveAt(randomIndex); //remove to avoid duplicates
		}

		return randomList; //return the new random list
	}

	private void buildMatrixPositions () {
		positions = new ArrayList ();
		for (int i = 1; i <= Mathf.Sqrt((float)pieces.Count); i++) {
			for (int j = 1; j <= Mathf.Sqrt((float)pieces.Count); j++) {
				positions.Add (i.ToString() + ";" + j.ToString());
			}
		}
	}

	void linkingPiecesAndPositions ()
	{
		int i = 0;
		foreach (GameObject pieceObj in pieces) {
			PieceScript piece = pieceObj.gameObject.GetComponent<PieceScript> ();
			string[] lineAndColumn = positions [i].ToString ().Split(';');
			piece.setLine(int.Parse (lineAndColumn [0]));
			piece.setColumn(int.Parse (lineAndColumn [1]));
			i++;
		}
	}
}
