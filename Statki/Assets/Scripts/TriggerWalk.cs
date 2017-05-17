using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TriggerWalk : MonoBehaviour {

    RivalsMov rivalsMove;
    Patrol patrol;
    public Transform enemy;
    public double rangeOfCourse = 4;
    public double rangeOfAttack = 1.5;
    public Transform bufforDestination;
    



    // Use this for initialization
    void Start () {
        rivalsMove = gameObject.GetComponent<RivalsMov>();
        patrol = gameObject.GetComponent<Patrol>();
    }

    void Update()
    {
		if (enemy != null)
		{
			Vector3 destination = enemy.position;
			Vector3 position = transform.position;

			double distanceOfVictim = distanceOfTwoVectors(destination, position);

			if (distanceOfVictim < rangeOfCourse)
			{
				rivalsMove.activeCourse = true;
				if (rivalsMove.destinationObject != enemy)
				{
					bufforDestination = rivalsMove.destinationObject;
					rivalsMove.destinationObject = enemy;
				}

				if (distanceOfVictim < rangeOfAttack)
					rivalsMove.activeAtack = true;
				else
					rivalsMove.activeAtack = false;
			}
			else
			{
				if (bufforDestination != null)
				{
					rivalsMove.destinationObject = bufforDestination;

					rivalsMove.activeCourse = true;
					bufforDestination = null;
				}

				if (patrol.trackElements.Length == 0)
				{
					rivalsMove.activeCourse = false;
					rivalsMove.activeAtack = false;
				}


			}
		}
		else
		{
			rivalsMove.activeCourse = false;
			rivalsMove.activeAtack = false;
		}
    }

    double distanceOfTwoVectors(Vector3 firstVector, Vector3 secondVector)
    {
        return Math.Sqrt(Math.Pow(firstVector.x - secondVector.x, 2) + Math.Pow(firstVector.y - secondVector.y, 2));
    }
}
