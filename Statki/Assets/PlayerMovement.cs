using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float maxSpeed = 1.0f;
	public float rotSpeed = 180f;
	float shipBoundaryRadius = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//rotation update
		Quaternion rot = transform.rotation;
		float z = rot.eulerAngles.z;
		z -= Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime;
		rot = Quaternion.Euler (0,0,z);
		transform.rotation = rot;

		//move update
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3(0,Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime,0);
		pos += rot * velocity;

		if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
		}
		if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
		}

		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrto = Camera.main.orthographicSize * screenRatio;

		if (pos.x + shipBoundaryRadius > widthOrto) {
			pos.x = widthOrto - shipBoundaryRadius;
		}
		if (pos.x - shipBoundaryRadius < -widthOrto) {
			pos.x = -widthOrto + shipBoundaryRadius;
		}

		transform.position = pos;

	}
}
