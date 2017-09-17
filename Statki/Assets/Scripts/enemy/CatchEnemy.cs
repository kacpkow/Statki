using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CatchEnemy : MonoBehaviour {

    public EnemyParam enemyParam;
    public 


    // Use this for initialization
    void Start () {
		gameObject.layer = 15;
        enemyParam = transform.parent.gameObject.GetComponent<EnemyParam>();
        GameObject mygameobject = new GameObject();
        randPosition(mygameobject);
        enemyParam.enemy = mygameobject.transform;
        enemyParam.patrol = true;
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

        if (enemyParam.patrol &&
            (distanceOfTwoVectors(enemyParam.enemy.position, transform.position) <= 10))
        {
            GameObject mygameobject = new GameObject();
            randPosition(mygameobject);
            enemyParam.enemy = mygameobject.transform;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            enemyParam.enemy = col.transform;
            enemyParam.patrol = false;
        }
    }

    

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject mygameobject = new GameObject();
            randPosition(mygameobject);
            enemyParam.enemy = mygameobject.transform;
            enemyParam.patrol = true;
        }
    }

    private void randPosition(GameObject objectt)
    {
        
        Vector3 vec= new Vector3();
        vec.x = UnityEngine.Random.Range(-100, 150);
        vec.y = UnityEngine.Random.Range(30, 50);
        objectt.transform.position = vec;
        
    }

    double distanceOfTwoVectors(Vector3 firstVector, Vector3 secondVector)
    {
        return Math.Sqrt(Math.Pow(firstVector.x - secondVector.x, 2) + Math.Pow(firstVector.y - secondVector.y, 2));
    }
}
