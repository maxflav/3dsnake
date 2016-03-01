using UnityEngine;
using System.Collections;

public class SnakeController : MonoBehaviour {
	public GameObject head;

	void Start () {
		StartCoroutine (MoveCycle ());
	}

	void Update () {
		if (Input.GetKeyDown ("w")) {
			head.transform.Rotate(Vector3.left * 90);
		} else if (Input.GetKeyDown ("a")) {
			head.transform.Rotate(Vector3.up * -90);
		} else if (Input.GetKeyDown ("s")) {
			head.transform.Rotate(Vector3.left * -90);
		} else if (Input.GetKeyDown ("d")) {
			head.transform.Rotate(Vector3.up * 90);
		}
	}

	IEnumerator MoveCycle() {
		while (true) {
			Move ();
			yield return new WaitForSeconds (1);
		}
	}

	void Move() {
		GameObject newPart = (GameObject)Instantiate (head, head.transform.position, head.transform.rotation);
		newPart.GetComponent<Renderer>().material.color = Color.green;
		head.transform.Translate (Vector3.forward);
	}
}
