using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Highscore : MonoBehaviour
{
    public delegate void pointsChanged(int points);
    public event pointsChanged pointsChangedEvent;

    private int points;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public int Points
    {
        get
        {            
            return points;
        }
        set {
            points = value;
            pointsChangedEvent?.Invoke(points);
        }
    }

    public string Username { get; set; }
}