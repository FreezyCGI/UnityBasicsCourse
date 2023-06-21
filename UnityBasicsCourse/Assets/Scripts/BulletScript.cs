using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        ShootingObjectScript shootingObjectScript = collision.gameObject.GetComponent<ShootingObjectScript>();
        if (shootingObjectScript)
        {
            shootingObjectScript.Destroy();
        }
        Destroy(gameObject);
    }
}
