using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuUIHandler : MonoBehaviour
{
    public InputField nameInput;
    public Text highScoreText;
    void Awake()
    {
        Debug.Log("On Start Menu UI Handler Awake");
        //SceneManager.LoadScene(0);
        //SceneManager.UnloadSceneAsync(1);
    }
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.UnloadSceneAsync(1);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
        if (HighScoreManager.instance != null && HighScoreManager.instance.Top10HighScores.Count > 0)
        {
            HighScoreData highScoreData = HighScoreManager.instance.Top10HighScores[0];
            highScoreText.text = $"Best Score : {highScoreData.HighScorePlayerName} : {highScoreData.HighScore}";
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        Debug.Log("Start Clicked");
        if (HighScoreManager.instance != null)
        {
            HighScoreManager.instance.currentPlayerName = nameInput.text;
            Debug.Log("On start name " + HighScoreManager.instance.currentPlayerName);
        }
        SceneManager.LoadScene(1);
    }

    public void DisplayHighScores()
    {
        if (HighScoreManager.instance != null)
        {
            Debug.Log("high score button clicked");
            SceneManager.LoadScene(2);
        }
    }

    public void ExitGame()
    {
#if (UNITY_EDITOR)
        {
            EditorApplication.ExitPlaymode();
        }
#else
        {
            Application.Quit();
        }
#endif

    }
}
