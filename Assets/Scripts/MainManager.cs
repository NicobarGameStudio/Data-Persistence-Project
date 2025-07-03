using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    public Text highScoreText;

    public GameObject returnToStartButton;


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("started main scene");
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }

        highScoreText.text = $"Next score to beat : {HighScoreManager.instance.scoreToBeat.HighScorePlayerName} : {HighScoreManager.instance.scoreToBeat.HighScore}";
        returnToStartButton.SetActive(true);
        
        
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
                returnToStartButton.SetActive(false);
            }
        }
        else if (m_GameOver)
        {
            returnToStartButton.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //SceneManager.LoadScene(0);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
        //Check for highScore
        Debug.Log("m_points"+m_Points+"  score to beat high score " + HighScoreManager.instance.scoreToBeat.HighScore);
        CheckScore();
        
    }

    void CheckScore()
    {
        if (m_Points > HighScoreManager.instance.scoreToBeat.HighScore)
        {
            updateScore();
        }
    }

    void updateScore()
    {
        HighScoreManager.instance.RefreshScores(m_Points,m_GameOver);
        highScoreText.text = $"Next score to beat : {HighScoreManager.instance.scoreToBeat.HighScorePlayerName} : {HighScoreManager.instance.scoreToBeat.HighScore}";
    }
    

    void RegisterHighScore(int score)
    {
        HighScoreManager.instance.highScore = score;
        HighScoreManager.instance.highScorePlayerName = HighScoreManager.instance.currentPlayerName;
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        updateScore();
        HighScoreManager.instance.SaveHighScore();
        /* if (m_Points > HighScoreManager.instance.highScore)
        {
            RegisterHighScore(m_Points);
            HighScoreManager.instance.SaveHighScore();
            highScoreText.text = $"Best Score : {HighScoreManager.instance.highScorePlayerName} : {HighScoreManager.instance.highScore}";
        } */
    }
}
