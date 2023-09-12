using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingObjectScript : MonoBehaviour
{
    public SpawnAreaScript SpawnAreaScript;
    private Highscore highscore;

    private void Start()
    {
        highscore = FindObjectOfType<Highscore>();
    }

    public void Destroy()
    {
        SpawnAreaScript.RemoveShootingObjectFromList(gameObject);
       
        HighScoreService highScoreService = new();
        highscore.Points++;       

        highScoreService.Put(highscore);

        Destroy(gameObject);    
    }
}
