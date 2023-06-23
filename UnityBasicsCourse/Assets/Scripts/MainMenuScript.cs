using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public InputField inputUsername;

    public void StartGame()
    {
        string username = inputUsername.text;

        HighScoreService highScoreService = new HighScoreService();
        StartCoroutine(highScoreService.Get(username, (highscore) =>
        {
            Highscore.Instance = highscore;
            SceneManager.LoadScene("ShootingRange");
        }));
    }
}