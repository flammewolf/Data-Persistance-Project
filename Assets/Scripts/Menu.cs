using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI username;

    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = "Best Score : " + MainManager.Instance.bestPlayerUsername + " : " + MainManager.Instance.bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickOnPlay()
    {
        if (username.text.Length >= 4) //if username ok
        {
            MainManager.Instance.SetUsername(username.text);
            SceneManager.LoadScene(1);
        }
        else if (username.text.Length <= 3 && username.text.Length > 1) //if username too short
        {
            Debug.Log("please enter a longer username");
        }
        else //if no username
        {
            Debug.Log("please enter a username first");
        }
    }

    public void ClickOnExit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }
}
