using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public InputField inputUsername;
    public Highscore highscore;

    public void StartGame()
    {
        string username = inputUsername.text;

        HighScoreService highScoreService = new HighScoreService();
        StartCoroutine(highScoreService.Get(username, (highscore) =>
        {
            this.highscore.Points = highscore.Points;
            this.highscore.Username = highscore.Username;
            SceneManager.LoadScene("ShootingRange");
        }));
    }
}