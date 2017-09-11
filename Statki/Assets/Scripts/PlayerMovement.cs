using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    float shipSpeed = 0.0f;
    float maxSpeed = 10;
    float rotSpeed = 180f;
	float shipBoundaryRadius = 20f;
    float shipDirection;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //rotation update
        Quaternion rot;
        shipDirection = transform.rotation.eulerAngles.z;

        shipDirection -= Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime;
		rot = Quaternion.Euler (0,0, shipDirection);

        transform.rotation = rot;

		

        var windDirectionObject = GameObject.Find("windDirection");
        var windControllerScript = (WindController)windDirectionObject.GetComponent("WindController");
        float windDirection = windControllerScript.transform.rotation.z;
        float windForce = windControllerScript.getForce();

        float wypadkowaStatku = (1 - Mathf.Abs(Mathf.Abs(windDirection) - Mathf.Abs(transform.rotation.z))) * windForce + shipSpeed;

        //move update
        Vector3 pos = transform.position;
        changeSpeed(Input.GetAxis("Vertical"));
        Vector3 velocity = new Vector3(0, maxSpeed * wypadkowaStatku * shipSpeed * Time.deltaTime, 0);
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

    private void changeSpeed(float speedChange)
    {
        shipSpeed += speedChange * 0.1f;
        if (shipSpeed > 1) shipSpeed = 1;
        else if (shipSpeed < 0) shipSpeed = 0;
    }
}
