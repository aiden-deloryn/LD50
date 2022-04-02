using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public Transform anchor;
	public bool followX, followY, followZ;
	public float moveSpeed;

	public bool rotateX, rotateY, rotateZ;
	public float rotateSpeed;

	void LateUpdate() {
		if (anchor != null) {
			Move();
			Rotate();
		}
	}

	private void Move() {
		float desiredX = followX ? anchor.transform.position.x : transform.position.x;
		float desiredY = followY ? anchor.transform.position.y : transform.position.y;
		float desiredZ = followZ ? anchor.transform.position.z : transform.position.z;
		Vector3 desiredPos = new Vector3(desiredX, desiredY, desiredZ);

		transform.position = Vector3.Lerp(transform.position, desiredPos, moveSpeed / 100);
	}

	private void Rotate() {
		float desiredRotationX = rotateX ? anchor.eulerAngles.x : transform.eulerAngles.x;
		float desiredRotationY = rotateY ? anchor.eulerAngles.y : transform.eulerAngles.y;
		float desiredRotationZ = rotateZ ? anchor.eulerAngles.z : transform.eulerAngles.z;

		Quaternion desiredRotation = Quaternion.Euler(desiredRotationX, desiredRotationY, desiredRotationZ);

		transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, rotateSpeed / 100);
	}
}