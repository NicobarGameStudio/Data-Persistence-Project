using System.Collections;
using System.Collections.Generic;
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
        highScoreText.text = $"Best Score : {HighScoreManager.instance.highScorePlayerName} : {HighScoreManager.instance.highScore}";
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
}
