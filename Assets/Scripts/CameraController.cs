using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject head;

	void LateUpdate () {
		transform.position = head.transform.position;
		transform.rotation = head.transform.rotation;
	}
}
