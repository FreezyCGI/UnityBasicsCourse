using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Highscore
{
    public static Highscore Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Highscore();
            }
            return instance;
        }
        set { instance = value; }
    }

    private static Highscore instance = null;

    public string username;
    public int points;
}