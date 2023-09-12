using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{ 
    public Text txtCounter;
    private HighScoreService highscoreService;

    private void Start()
    {
        highscoreService = FindObjectOfType<HighScoreService>();
        highscoreService.pointsChangedEvent += Highscore_pointsChangedEvent;
        SetTxtCounterNumber(highscoreService.Points);
    }
    private void Highscore_pointsChangedEvent(int points)
    {
        SetTxtCounterNumber(points);
    }

    public void SetTxtCounterNumber(int counter)
    {
        txtCounter.text = "Hits: " + counter;
    }
}
