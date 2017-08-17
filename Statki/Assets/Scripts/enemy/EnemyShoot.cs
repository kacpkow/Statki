using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    GameObject toSound;

    public GameObject bulletPrefab;
    int bulletLayer;

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;

    public EnemyParam enemyParam;

    void Start()
    {
        enemyParam = transform.gameObject.GetComponent<EnemyParam>();
        bulletLayer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyParam.fire)
        {
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0)
            {
                // SHOOT!
                cooldownTimer = fireDelay;

                Vector3 offset = transform.rotation * bulletOffset;

                GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
                AudioSource M4A1 = GetComponent<AudioSource>();
                M4A1.Play();
                bulletGO.layer = bulletLayer;
            }

        }
    }
}

