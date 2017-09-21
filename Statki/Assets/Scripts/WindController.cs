using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindController : MonoBehaviour
{

    float direction;
    int force;
    public Text windForce;
    float cooldownTimer = 0;
    float changeDelay = 5;
    float windChange = 1;
    Quaternion rot;
    float smooth = 0.5f;

    // Use this for initialization
    void Start()
    {
        direction = 0;
        force = 1;
        //windForce.text = "Wind force: " + force;
    }

    public int getForce()
    {
        return force;
    }

    public float getDirection()
    {
        return direction;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0)
        {
            force = Random.Range(1, 3);
            //windForce.text = "Wind force: " + force;
            windChange = Random.Range(-45.0f, 45.0f);
            direction += windChange + transform.rotation.z;
            rot = Quaternion.Euler(0, 0, direction);
            cooldownTimer = changeDelay;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * smooth);
    }
}
