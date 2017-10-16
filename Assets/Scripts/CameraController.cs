using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float moveSpeed;
	public float edgeLimit; // amount of pixels from edge of screen that should register movement

	void LateUpdate() {

		float moveX, moveY, moveZ;
		moveX = moveY = moveZ = 0.0f;

		// key based movement
		moveX += Input.GetAxis("Horizontal") * moveSpeed;
		moveZ += Input.GetAxis("Vertical") * moveSpeed;

		// mouse at edges of screen movement
		if (0.0f <= Input.mousePosition.x && Input.mousePosition.x < edgeLimit) {
			moveX -= moveSpeed;
		}
		else if (Screen.width > Input.mousePosition.x && Input.mousePosition.x > Screen.width - edgeLimit) {
			moveX += moveSpeed;
		}
		if (0.0f <= Input.mousePosition.y && Input.mousePosition.y < edgeLimit) {
			moveZ -= moveSpeed;
		}
		else if (Screen.height > Input.mousePosition.y && Input.mousePosition.y > Screen.height - edgeLimit) {
			moveZ += moveSpeed;
		}

		// mouse drag terrain movement
		if (Input.GetMouseButton(0)) {
			moveX = -Input.GetAxis("Mouse X") * moveSpeed;
			moveZ = -Input.GetAxis("Mouse Y") * moveSpeed;
		}

		Vector3 movement = new Vector3(moveX, moveY, moveZ);
		transform.Translate(movement, Space.World);
	}
}
