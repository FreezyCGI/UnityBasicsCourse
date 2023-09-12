using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ShootingObjectScript : MonoBehaviour
{
    public SpawnAreaScript SpawnAreaScript;
    private HighScoreService highscoreService;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        highscoreService = FindObjectOfType<HighScoreService>();
    }

    public void Destroy()
    {
        SpawnAreaScript.RemoveShootingObjectFromList(gameObject);
       
        highscoreService.Points++;
        Task.Run(() =>
        {
            highscoreService.PutAsync();
        });
      
        Destroy(gameObject);    
    }
}
