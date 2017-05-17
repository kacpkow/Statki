using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Patrol : MonoBehaviour {

    public Transform[] trackElements;
    RivalsMov rivalsMov;
    public int numberOfElementInTrack = 0;

    // Use this for initialization
    void Start () {
        rivalsMov = transform.GetComponent<RivalsMov>();

        if (trackElements.Length > 0)
        {
            rivalsMov.destinationObject = trackElements[0];
            rivalsMov.activeCourse = true;
        }
        else
            rivalsMov.activeCourse = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(trackElements.Length > 0)
        {
            if (distanceOfTwoVectors(transform.position, trackElements[numberOfElementInTrack].position) < 0.4)
            {
                if (trackElements.Length == numberOfElementInTrack+1)
                    numberOfElementInTrack = -1;

                numberOfElementInTrack++;
                rivalsMov.destinationObject = trackElements[numberOfElementInTrack];
                rivalsMov.activeCourse = true;
            }
        }
	}

    double distanceOfTwoVectors(Vector3 firstVector, Vector3 secondVector)
    {
        return Math.Sqrt(Math.Pow(firstVector.x - secondVector.x, 2) + Math.Pow(firstVector.y - secondVector.y, 2));
    }
}
