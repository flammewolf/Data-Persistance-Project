using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public string username;
    public string bestPlayerUsername = "";
    public int bestScore = 0;

    
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }

    private void Update()
    {
        
    }

    public void SetUsername(string text)
    {
        username = text;
    }

    [System.Serializable]
    class BestScore
    {
        public string username;
        public int score;
    }

    public void SaveBestScore()
    {
        BestScore data = new BestScore();
        data.username = bestPlayerUsername;
        data.score = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/scorefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/scorefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestScore data = JsonUtility.FromJson<BestScore>(json);

            bestPlayerUsername = data.username;
            bestScore = data.score;
        }
    }

    public string GetBestPlayerUsername()
    {
        return bestPlayerUsername;
    }

    public int GetBestScore()
    {
        return bestScore;
    }

}
