using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingObjectScript : MonoBehaviour
{
    public SpawnAreaScript SpawnAreaScript;
    public static int timesHit = 0;

    public void Destroy()
    {
        SpawnAreaScript.RemoveShootingObjectFromList(gameObject);
        timesHit++;
        UIScript.instance.SetTxtCounterNumber(timesHit);
        Destroy(gameObject);
    }
}
