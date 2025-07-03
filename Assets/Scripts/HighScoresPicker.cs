using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoresPicker : MonoBehaviour
{
    public Text highScoreText;

    public void Init()
    {
        List<HighScoreData> highScores = HighScoreManager.instance.Top10HighScores;
        Debug.Log("IN high scores start list size : "+highScores.Count);
        foreach (HighScoreData highScore in highScores)
        {
            var text = Instantiate(highScoreText, transform);
            text.text = $"{highScore.HighScorePlayerName} : {highScore.HighScore}";
            Debug.Log("high score = " + highScoreText.text);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
