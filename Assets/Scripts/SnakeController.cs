using UnityEngine;
using System.Collections;

public class SnakeController : MonoBehaviour {
	public GameObject head;

	void Start () {
		StartCoroutine (MoveCycle ());
	}

	void Update () {
		float pitch = 0;
		float yaw = 0;
		float roll = 0;

		if (Input.GetKeyDown ("w")) { pitch += 1; }
		if (Input.GetKeyDown ("s")) { pitch -= 1; }

		if (Input.GetKeyDown ("a")) { yaw -= 1; }
		if (Input.GetKeyDown ("d")) { yaw += 1; }

		if (Input.GetKeyDown ("q")) { roll -= 1; }
		if (Input.GetKeyDown ("e")) { roll += 1; }

		if (pitch == 0 && yaw == 0 && roll == 0) {
			return;
		}

		Vector3 rotVector = new Vector3(-pitch, yaw, -roll);
		head.transform.Rotate(rotVector * 90);
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
