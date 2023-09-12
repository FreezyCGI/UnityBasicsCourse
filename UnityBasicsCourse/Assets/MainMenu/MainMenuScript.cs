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

        var highscoreService = FindObjectOfType<HighScoreService>();
        StartCoroutine(highscoreService.Get(username, () =>
        {         
            SceneManager.LoadScene("ShootingRange");
        }));
    }
}