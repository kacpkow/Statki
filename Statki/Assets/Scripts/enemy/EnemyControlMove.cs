using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyControlMove : MonoBehaviour {

    public EnemyParam enemyParam;

    public float angle;
    public float angleOfObstance;
    public int angleOfDeadSpace;

    // Use this for initialization
    void Start () {
        enemyParam = transform.gameObject.GetComponent<EnemyParam>();
        angleOfDeadSpace = 10;
    }
	
	// Update is called once per frame
	void Update () {
        if (enemyParam.activeWalk)
        {
            if (enemyParam.obstance == null)
            {
                if (enemyParam.activeAttack)
                {
                    
                    atack();
                }
                else
                {
                    swimToTarget();
                    enemyParam.fire = false;
                }

            }
            else
            {
                skipObstance();
                enemyParam.fire = false;
            }
        }
        else
        {
            if (enemyParam.moveDown) enemyParam.moveDown = false;
            if (enemyParam.moveUp) enemyParam.moveUp = false;
            if (enemyParam.moveLeft) enemyParam.moveLeft = false;
            if (enemyParam.moveRight) enemyParam.moveRight = false;
            if (enemyParam.fire) enemyParam.fire = false;
        }

    }

    void atack()
    {
		if (enemyParam.enemy != null) {
			angle = calculateAngle(enemyParam.enemy.position);
			enemyParam.moveUp = true;

			int angleOfApproach = 270;
			int leftRange = angleOfApproach - angleOfDeadSpace / 2;
			int rightRange = angleOfApproach + angleOfDeadSpace / 2;

			if (angle < leftRange && angle > 90)
				goLeft();
			else if ((angle > rightRange && angle < 360) || (angle > 0 && angle < 90))
				goRight();
			else
			{
				enemyParam.fire = true;
				noTwist();
			}

		}
    }

    void swimToTarget()
    {
		if (enemyParam.enemy != null) {
			angle = calculateAngle(enemyParam.enemy.position);
			enemyParam.moveUp = true;

			int leftRange = 360 - angleOfDeadSpace / 2;
			int rightRange = 0 + angleOfDeadSpace / 2;

			if (angle > rightRange && angle <= 180)
				goRight();
			else if (angle > 180 && angle < leftRange)
				goLeft();
			else if ((angle >= leftRange || angle <= rightRange))
				noTwist();
		}

    }

    void skipObstance()
    {
        angleOfObstance = calculateAngle(enemyParam.obstance.position);
        angle = calculateAngle(enemyParam.enemy.position);
        enemyParam.moveUp = true;

        int angleOfApproach ;
        int leftRange;
        int rightRange;

        if (angleOfObstance > 0 && angleOfObstance < 180)
        {
            if (angle <= 360 && angle > 180)
                enemyParam.obstance = null;

            angleOfApproach = 90;
            leftRange= angleOfApproach - angleOfDeadSpace / 2;
            rightRange = angleOfApproach + angleOfDeadSpace / 2;
            if (angleOfObstance < leftRange)
                goLeft();
            else if (angleOfObstance > rightRange)
                goRight();
            else noTwist();
        }
        else {
            if (angle >= 0 && angle < 180)
                enemyParam.obstance = null;

            angleOfApproach = 270;
            leftRange = angleOfApproach - angleOfDeadSpace / 2;
            rightRange = angleOfApproach + angleOfDeadSpace / 2;
            if (angleOfObstance < leftRange)
                goRight();
            else if (angleOfObstance > rightRange)
                goLeft();
            else noTwist();

        }


    }

    void goLeft()
    {
        enemyParam.moveLeft = true;
        enemyParam.moveRight = false;
    }

    void goRight()
    {
        enemyParam.moveRight = true;
        enemyParam.moveLeft = false;
    }

    void noTwist()
    {
        enemyParam.moveRight = false;
        enemyParam.moveLeft = false;
    }

    float calculateAngle(Vector3 objectToCalculatePosition)
    {
        Vector3 enemyPosition = transleteToBeginOfCoordinateSystem(transform.position, objectToCalculatePosition);
        Vector3 verticalLine = new Vector3(0, enemyPosition.y, 0);

        double distanceVerticalLine = distanceOfTwoVectors(new Vector3(0, 0, 0), verticalLine);
        double distanceEnemy = distanceOfTwoVectors(new Vector3(0, 0, 0), enemyPosition);

        double cosinus = distanceVerticalLine / distanceEnemy;

        float angleBuffor = (int)(180 * Math.Acos(cosinus) / 3.14);

        //w pierwszeh cwiartce bez zmian
        if (enemyPosition.x < 0 && enemyPosition.y > 0)
        {// druga cwiartka
            angleBuffor = 360 - angleBuffor;
        }
        else if (enemyPosition.x < 0 && enemyPosition.y < 0)
        {// trzecia cwiartka
            angleBuffor = 180 + angleBuffor;
        }
        else if (enemyPosition.x > 0 && enemyPosition.y < 0)
        {//czwarta cwiartka
            angleBuffor = 180 - angleBuffor;
        }

        //180 obrocona tekstura
        float rotation = transform.rotation.eulerAngles.z + 180;
        if (rotation > 360) rotation -= 360;
        rotation = 360 - rotation;

        angleBuffor -= rotation;
        if (angleBuffor < 0) angleBuffor += 360;


        return angleBuffor;
    }

    Vector3 transleteToBeginOfCoordinateSystem(Vector3 toBegin, Vector3 toTranslate)
    {
        Vector3 result = new Vector3();
        float vectorX = 0 - toBegin.x;
        float vectorY = 0 - toBegin.y;

        result.x = toTranslate.x + vectorX;
        result.y = toTranslate.y + vectorY;

        return result;
    }

    double distanceOfTwoVectors(Vector3 firstVector, Vector3 secondVector)
    {
        return Math.Sqrt(Math.Pow(firstVector.x - secondVector.x, 2) + Math.Pow(firstVector.y - secondVector.y, 2));
    }
}
