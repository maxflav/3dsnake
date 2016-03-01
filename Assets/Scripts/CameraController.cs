using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject head;

	// private Vector3 offset;

	void Start ()
	{
		// offset = transform.position - head.transform.position;
	}

	void LateUpdate ()
	{
		// transform.position = head.transform.position + offset;
		// transform.rotation = head.transform.rotation;
	}
}
