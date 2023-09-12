using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{ 
    public Text txtCounter;
    private Highscore highscore;

    private void Start()
    {
        highscore = FindObjectOfType<Highscore>();
        highscore.pointsChangedEvent += Highscore_pointsChangedEvent;

        SetTxtCounterNumber(highscore.Points);
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
