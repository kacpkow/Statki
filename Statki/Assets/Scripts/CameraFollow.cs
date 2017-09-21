using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	private Transform myTarget;
    private Transform wind;

    [SerializeField]
    private float xMax;

    [SerializeField]
    private float yMax;

    [SerializeField]
    private float xMin;

    [SerializeField]
    private float yMin;

    void Start() {
        myTarget = GameObject.Find("lodz(Clone)").transform;
    }

    // Update is called once per frame
    void Update () {
        myTarget = GameObject.Find("lodz(Clone)").transform;
        transform.position = new Vector3(Mathf.Clamp(myTarget.position.x, xMin, xMax), Mathf.Clamp(myTarget.position.y, yMin, yMax), transform.position.z);
	}
}
