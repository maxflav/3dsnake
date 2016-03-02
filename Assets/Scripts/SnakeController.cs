using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeController : MonoBehaviour {
	public GameObject head;
	private Queue<GameObject> tailQ = new Queue<GameObject> ();

	private int globalPitch = 0;
	private int globalYaw = 0;

	private GameObject neck;

	void Start () {
		head.GetComponent<MeshRenderer> ().enabled = false;
		StartCoroutine (MoveCycle ());
	}

	void Update () {
		int pitch = 0;
		int yaw = 0;
		int roll = 0;

		if (Input.GetKeyDown ("w")) { pitch += 1; }
		if (Input.GetKeyDown ("s")) { pitch -= 1; }

		if (Input.GetKeyDown ("a")) { yaw -= 1; }
		if (Input.GetKeyDown ("d")) { yaw += 1; }

		if (Input.GetKeyDown ("q")) { roll -= 1; }
		if (Input.GetKeyDown ("e")) { roll += 1; }

		if (pitch == 0 && yaw == 0 && roll == 0) {
			return;
		}

		// These prevent you from spinning all the way round.
		// The head can't do a full 180 otherwise it would immediately die.
		// Twisting around with Roll is fine I guess.
		// Actually this doesn't completely work because if yaw=1 and roll=1 and pitch=1 you end up spun around.
		// Shrug oh well lol
		if (globalPitch + pitch >= 2) { pitch = 0; }
		if (globalYaw + yaw >= 2) { yaw = 0; }
		globalPitch += pitch;
		globalYaw += yaw;

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
		if (neck != null) {
			// Tail part immediately behind head (and head) are not visible, otherwise they overlap camera too much
			neck.GetComponent<MeshRenderer> ().enabled = true;
		}

		Vector3 prevHeadPosition = head.transform.position;

		globalPitch = 0;
		globalYaw = 0;
		head.transform.Translate (Vector3.forward);

		if (Mathf.Abs(head.transform.position.x) > 5 || Mathf.Abs(head.transform.position.y) > 5 || Mathf.Abs(head.transform.position.z) > 5) {
			head.transform.Translate (Vector3.back);
			die ();
			return;
		}

		foreach (GameObject tailPart in tailQ) {
			if (samePosition(head.transform.position, tailPart.transform.position)) {
				head.transform.Translate (Vector3.back);
				die ();
				return;
			}
		}

		// Only create neck part if we didn't die

		neck = (GameObject)Instantiate (head, prevHeadPosition, head.transform.rotation);
		neck.GetComponent<MeshRenderer> ().enabled = false;
		neck.GetComponent<Renderer>().material.color = Color.green;
		tailQ.Enqueue (neck);
	}

	bool samePosition(Vector3 a, Vector3 b) {
		return closeFloats (a.x, b.x) && closeFloats (a.y, b.y) && closeFloats (a.z, b.z);
	}

	bool closeFloats(float a, float b) {
		return Mathf.RoundToInt (a) == Mathf.RoundToInt (b);
	}

	void die() {
		Debug.Log ("Dead " + head.transform.position);
	}
}
