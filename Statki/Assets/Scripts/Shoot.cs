using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public void ShootBullet(Vector3 bulletOffset, int direction, Vector3 position, Quaternion rotation, GameObject bulletPrefab)
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, position + rotation * bulletOffset, rotation);
        bulletGO.GetComponent<MoveForwardBullet>().transform.Rotate(0, 0, direction);
        bulletGO.layer = gameObject.layer;
    }
}
