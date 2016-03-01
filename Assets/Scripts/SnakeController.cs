using UnityEngine;
using System.Collections;

public class SnakeController : MonoBehaviour {
	public GameObject head;

	private Vector3 direction = new Vector3 (0, 0, 1);

	// Use this for initialization
	void Start () {
		transform.rotation = Quaternion.LookRotation (direction);
		StartCoroutine (MoveCycle ());
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("w")) {
			//Debug.Log (direction);
			direction = Quaternion.AngleAxis (90, Vector3.left) * direction;
			//Debug.Log (direction);
		}
		else if (Input.GetKeyDown ("a")) {
			//Debug.Log (direction);
			direction = Quaternion.AngleAxis (90, Vector3.forward) * direction;
			//Debug.Log (direction);
		}
		else if (Input.GetKeyDown ("s")) {
			//Debug.Log (direction);
			direction = Quaternion.AngleAxis (90, Vector3.right) * direction;
			//Debug.Log (direction);
		}
		else if (Input.GetKeyDown ("d")) {
			Debug.Log (direction);
			direction = Quaternion.AngleAxis (90, Vector3.up) * direction;
			Debug.Log (direction);
		}
		
		transform.localRotation = Quaternion.LookRotation (direction);
	}

	IEnumerator MoveCycle() {
		Debug.Log ("!!!! MoveCycle() !!!!");
		while (true) {
			Move ();
			yield return new WaitForSeconds (1);
		}
	}

	void Move() {
		print ("********* MOVE() *********");
		print ("old head position: " + head.transform.position);
		GameObject newPart = (GameObject)Instantiate (head, head.transform.position, head.transform.rotation);
		print ("bodypart position: " + newPart.transform.position);
		newPart.GetComponent<Renderer>().material.color = Color.green;
		print ("Translating head:" + direction);
		head.transform.Translate (direction);
		print("new head position: " + head.transform.position);
	}
}
