using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CatchEnemy : MonoBehaviour {

    public EnemyParam enemyParam;


    // Use this for initialization
    void Start () {
		gameObject.layer = 15;
        enemyParam = transform.parent.gameObject.GetComponent<EnemyParam>();
    }
	
	// Update is called once per frame
	void Update () {
        if (enemyParam.enemy != null) enemyParam.activeWalk = true;
        else enemyParam.activeWalk = false;

        if (enemyParam.activeWalk && 
            (distanceOfTwoVectors(enemyParam.enemy.position, transform.position) <= enemyParam.rangeOfAttack))
            enemyParam.activeAttack = true;
        else
            enemyParam.activeAttack = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            enemyParam.enemy = col.transform;
        }
    }

    

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            enemyParam.enemy = null;
        }
    }

    double distanceOfTwoVectors(Vector3 firstVector, Vector3 secondVector)
    {
        return Math.Sqrt(Math.Pow(firstVector.x - secondVector.x, 2) + Math.Pow(firstVector.y - secondVector.y, 2));
    }
}
