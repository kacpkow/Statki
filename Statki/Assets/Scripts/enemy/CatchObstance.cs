using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchObstance : MonoBehaviour {

    public EnemyParam enemyParam;

    // Use this for initialization
    void Start () {
		gameObject.layer = 15;
        enemyParam = transform.parent.gameObject.GetComponent<EnemyParam>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.tag == "Land")
        {
            if(enemyParam.patrol)
            {
                GameObject mygameobject = new GameObject();
                randPosition(mygameobject);
                enemyParam.enemy = mygameobject.transform;
            }

            enemyParam.numberOfObstance++;
            enemyParam.obstance = col.transform;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
		if (col.gameObject.tag == "Land")
        {
            enemyParam.numberOfObstance--;
            if (enemyParam.numberOfObstance <= 0)
            {
                enemyParam.obstance = null;
                enemyParam.numberOfObstance = 0;
            }
        }
    }

    private void randPosition(GameObject objectt)
    {

        Vector3 vec = new Vector3();
        vec.x = UnityEngine.Random.Range(-100, 150);
        vec.y = UnityEngine.Random.Range(30, 50);
        objectt.transform.position = vec;

    }
}
