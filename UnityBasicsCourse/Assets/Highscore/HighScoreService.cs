using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class HighScoreService : MonoBehaviour 
{
    private Highscore Highscore { get; set; }

    public delegate void pointsChanged(int points);
    public event pointsChanged pointsChangedEvent;

    public int Points
    {
        get
        {
            return Highscore.points;
        }
        set
        {
            Highscore.points = value;
            pointsChangedEvent?.Invoke(Highscore.points);
        }
    }
    public string Username { get => Highscore.username; }

    private void Start()
    {
        Highscore = new Highscore();
        DontDestroyOnLoad(this.gameObject);
    }

    public async Task PutAsync()
    {
        string myJson = JsonUtility.ToJson(Highscore);
        Debug.Log($"PutAsync(): username: {Highscore.username}");
        Debug.Log($"PutAsync(): points: {Highscore.points}");

        HttpClient client = new();
        HttpRequestMessage requestMessage = new(HttpMethod.Put, "http://localhost:3000/Highscore/{Highscore.username}");
        requestMessage.Content = new StringContent(myJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.SendAsync(requestMessage);

        //using var client = new HttpClient();
        //client.Content = new ByteArrayContent(content);
        //var response = client.PutAsync(
        //    $"http://localhost:3000/Highscore/{Highscore.username}",
        //     new StringContent(myJson, Encoding.UTF8, "application/json"));
    }

    public IEnumerator Get(string username, System.Action OnFinish)
    {
        UnityWebRequest www = UnityWebRequest.Get($"http://localhost:3000/Highscore/{username}");
        yield return www.SendWebRequest();

        Highscore.username = username;

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            var highscore = JsonUtility.FromJson<Highscore>(www.downloadHandler.text);
            Highscore.points = highscore.points;
            Debug.Log($"Loaded: username: {Highscore.username}");
            Debug.Log($"Loaded: Points: {Highscore.points}");
        }
        OnFinish();
    }
}
