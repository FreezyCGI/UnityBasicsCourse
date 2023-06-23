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
       
        HighScoreService highScoreService = new HighScoreService();
        Highscore.Instance.points++;
        UIScript.instance.SetTxtCounterNumber(Highscore.Instance.points);

        highScoreService.Post(Highscore.Instance);

        Destroy(gameObject);    
    }
}
