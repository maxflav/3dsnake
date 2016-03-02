using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject head;

	private Vector3 lastCameraPosition;
	private Vector3 currentHeadPosition;
	private float lastPositionTime;

	private Quaternion lastCameraRotation;
	private Quaternion currentHeadRotation;
	private float lastRotationTime;

	void Start () {
		transform.position = head.transform.position;
		lastCameraPosition = head.transform.position;
		currentHeadPosition = head.transform.position;
		lastPositionTime = Time.time;

		transform.rotation = head.transform.rotation;
		lastCameraRotation = head.transform.rotation;
		currentHeadRotation = head.transform.rotation;
		lastRotationTime = Time.time;
	}

	void Update () {

		transform.position = Vector3.Lerp (lastCameraPosition, currentHeadPosition, (Time.time - lastPositionTime));

		if (head.transform.position != currentHeadPosition) {
			// Head has moved
			lastCameraPosition = transform.position;
			currentHeadPosition = head.transform.position;
			lastPositionTime = Time.time;
		}

		transform.rotation = Quaternion.Lerp (lastCameraRotation, currentHeadRotation, (Time.time - lastRotationTime) * 3);

		if (head.transform.rotation != currentHeadRotation) {
			// Head has turned
			lastCameraRotation = transform.rotation;
			currentHeadRotation = head.transform.rotation;
			lastRotationTime = Time.time;
		}
	}
}
