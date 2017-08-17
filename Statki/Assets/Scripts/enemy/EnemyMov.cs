using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour {

    public EnemyParam enemyParam;
    private int horizontal;
    private int vertical;

    // Use this for initialization
    void Start () {
        enemyParam = transform.gameObject.GetComponent<EnemyParam>();
    }
	
	// Update is called once per frame
	void Update () {
        if (enemyParam.moveUp) vertical = -1;
        else if (enemyParam.moveDown) vertical = 1;
        else vertical = 0;

        if (enemyParam.moveRight) horizontal = 1;
        else if (enemyParam.moveLeft) horizontal = -1;
        else horizontal = 0;

        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= horizontal * enemyParam.rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        //move update
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, vertical * enemyParam.maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity;

        transform.position = pos;
    }
}
