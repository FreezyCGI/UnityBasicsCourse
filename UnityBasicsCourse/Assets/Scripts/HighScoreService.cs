using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class HighScoreService
{

    public void Post(Highscore highscore)
    {
        string myJson = JsonUtility.ToJson(highscore);
        Debug.Log(highscore.username);
        using (var client = new HttpClient())
        {
            var response = client.PostAsync(
                "http://localhost:3000/highscore",
                 new StringContent(myJson, Encoding.UTF8, "application/json"));
        }
    }

    public IEnumerator Get(string username, System.Action<Highscore> OnFinish)
    {
        UnityWebRequest www = UnityWebRequest.Get($"http://localhost:3000/highscore/{username}");
        yield return www.SendWebRequest();

        Highscore highscore = new Highscore();
        highscore.username = username;

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            highscore = JsonUtility.FromJson<Highscore>(www.downloadHandler.text);
            highscore.username = username;
        }
        OnFinish(highscore);
    }
}
