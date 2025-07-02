using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuUIHandler : MonoBehaviour
{
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
            
        }
        SceneManager.LoadScene(1);
    }
}
