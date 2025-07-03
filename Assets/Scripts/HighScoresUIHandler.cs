using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoresUIHandler : MonoBehaviour
{
    public HighScoresPicker highScoresPicker;
    // Start is called before the first frame update
    void Start()
    {
        highScoresPicker.Init();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenStartMenu()
    {
        SceneManager.LoadScene(0);
    }
}
