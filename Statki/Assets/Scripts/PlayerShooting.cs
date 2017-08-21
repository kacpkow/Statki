using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShooting : MonoBehaviour
{
    private Vector3 bulletOffsetRight = new Vector3(5, 0, 0);
    private Vector3 bulletOffsetLeft = new Vector3(-5, 0, 0);

    public GameObject bulletPrefab;

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            // SHOOT!
            cooldownTimer = fireDelay;
            // SHOOT! from right
            GetComponent<Shoot>().ShootBullet(bulletOffsetRight, 0, transform.position, transform.rotation, bulletPrefab);
            //SHOOT! from left
            GetComponent<Shoot>().ShootBullet(bulletOffsetLeft, 180, transform.position, transform.rotation, bulletPrefab);

            //Sound
            AudioSource M4A1 = GetComponent<AudioSource>();
            M4A1.Play();
        }
    }
}




