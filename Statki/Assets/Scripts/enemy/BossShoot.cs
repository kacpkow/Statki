using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour {

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

                offset.x -= 5;
                GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
                offset.x += 5;
                GameObject bulletGO2 = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
                offset.x += 5;
                GameObject bulletGO3 = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);


                //GetComponent<Shoot>().ShootBullet(bulletOffset, 0, transform.position, transform.rotation, bulletPrefab);
                //offset.y += 20;
                //GetComponent<Shoot>().ShootBullet(bulletOffset, 0, transform.position, transform.rotation, bulletPrefab);

                AudioSource M4A1 = GetComponent<AudioSource>();
                M4A1.Play();
                bulletGO.layer = bulletLayer;
                bulletGO2.layer = bulletLayer;
                bulletGO3.layer = bulletLayer;
            }

        }
    }
}
