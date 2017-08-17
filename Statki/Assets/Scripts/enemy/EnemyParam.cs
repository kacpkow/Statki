using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyParam : MonoBehaviour {

    public Transform enemy;
    public Transform obstance;
    public int numberOfObstance;
    public bool activeWalk;
    public bool activeAttack;
    public long maxSpeed;
    public float rotSpeed;
    public long rangeOfAttack;

    public bool moveUp;
    public bool moveDown;
    public bool moveLeft;
    public bool moveRight;
    public bool fire;

    // Use this for initialization
    void Start () {
        maxSpeed = 10;
        rotSpeed = 320F;
    }
	
	// Update is called once per frame
	void Update () {
    }

}
