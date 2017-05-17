using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RivalsMov : MonoBehaviour {

    public Transform destinationObject;
    public float maxSpeed = 1.0f;
    public bool activeCourse = false;
    public bool activeAtack = false;
    public int angle = 0;

    EnemyShoot enemyShoot;

    void Start()
    {
        enemyShoot = gameObject.GetComponent<EnemyShoot>();
    }
	
	// Update is called once per frame
	void Update () {
        if (activeCourse)
        {
            if (activeAtack)
                attackObject();
            else
            {
                moveToObject();
                enemyShoot.active = false;
            }
        }
    }

    void attackObject()
    {
        Vector3 destination = destinationObject.position;
        Vector3 position = transform.position;

        angle = angleDestinationPosition(position, destination);

        //obliczenie kierunku skrętu
        if (angle < 80 || angle > 100)
        {
            int horizontal = 0;
            if (position.x < destination.x)
                horizontal = -1;
            else if (position.x > destination.x)
                horizontal = 1;

            position = oneStep(position, horizontal, 0, maxSpeed, 180f);
        }
        

        if (angle < 80 || angle > 100)
            enemyShoot.active = false;
        else
            enemyShoot.active = true;


        position = oneStep(position, 0, -1, maxSpeed, 180f);

        transform.position = position;
    }

    void moveToObject()
    {
        Vector3 destination = destinationObject.position;
        Vector3 position = transform.position;

        angle = angleDestinationPosition(position,destination);
        float speedInTurn = maxSpeed;
        //obliczenie kierunku skrętu
        if (angle < 170)
        {
            int horizontal = 0;
            if (position.x < destination.x)
                horizontal = -1;
            else if (position.x > destination.x)
                horizontal = 1;

            speedInTurn = 0.2f;
            position = oneStep(position, horizontal, 0, speedInTurn, 180f);
        }
        
        position = oneStep(position, 0, -1, speedInTurn, 180f);

        transform.position = position;
    }

    int angleDestinationPosition(Vector3 position, Vector3 destination)
    {
        Vector3 direction = oneStep(position, 0, 40, maxSpeed, 180f);

        //obliczenie kata po miedzy kierunkiem statku a ofiara
        double distancePositionDirectionA = distanceOfTwoVectors(position, direction);
        double distancePositionDestinationC = distanceOfTwoVectors(position, destination);
        double distanceDestinationDirectionB = distanceOfTwoVectors(destination, direction);

        double cosinus = (Math.Pow(distancePositionDirectionA, 2) + Math.Pow(distancePositionDestinationC, 2) - Math.Pow(distanceDestinationDirectionB, 2))
            / (2 * distancePositionDirectionA * distancePositionDestinationC);

        int angle = (int)(180 * Math.Acos(cosinus) / 3.14);


        return angle;
    }

    Vector3 oneStep(Vector3 position, int horizontal, int vertical, float maxSpeed, float rotSpeed)
    {
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= horizontal * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        //move update
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, vertical * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity;

        return pos;
    }

    double distanceOfTwoVectors(Vector3 firstVector, Vector3 secondVector)
    {
        return Math.Sqrt(Math.Pow(firstVector.x - secondVector.x, 2) + Math.Pow(firstVector.y - secondVector.y, 2));
    }
}
