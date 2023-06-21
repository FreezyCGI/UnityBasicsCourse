using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingObjectScript : MonoBehaviour
{
    public SpawnAreaScript SpawnAreaScript;

    public void Destroy()
    {
        SpawnAreaScript.RemoveShootingObjectFromList(gameObject);
        Destroy(gameObject);
    }

}
