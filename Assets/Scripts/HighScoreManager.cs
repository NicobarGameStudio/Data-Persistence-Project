using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager instance;
    public string currentPlayerName;
    public int highScore;
    public string highScorePlayerName;

    public HighScoreData scoreToBeat;
    public List<HighScoreData> Top10HighScores;
    public String selectedDifficultyToggle;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /* [System.Serializable]
    public class HighScoreData
    {
        public string HighScorePlayerName;
        public int HighScore;
    } */
    [System.Serializable]
    class SaveData
    {
        public String difficultyToggle;
        public List<HighScoreData> Top10HighScores;
    }
    public void RefreshScores(int points, bool gameOver)
    {
        /* if (instance.Top10HighScores == null)
        {
            instance.Top10HighScores = new List<HighScoreData>();
        } */
        int insertIndex = instance.Top10HighScores.FindIndex(obj => points > obj.HighScore);
        if (insertIndex != -1 || instance.Top10HighScores.Count < 10)
        {
            Debug.Log("insert index : " + insertIndex);
            if (insertIndex == -1)
            {
                insertIndex = instance.Top10HighScores.Count;
            }

            if (insertIndex > 0)
            {
                scoreToBeat = instance.Top10HighScores[insertIndex - 1];
            }
            
            if (insertIndex > 0)
            {
                scoreToBeat = instance.Top10HighScores[insertIndex - 1];
            }

            if (gameOver)
            {
                HighScoreData highScoreData = new HighScoreData();
                highScoreData.HighScorePlayerName = instance.currentPlayerName;
                highScoreData.HighScore = points;
                instance.Top10HighScores.Insert(insertIndex, highScoreData);
                Debug.Log("after insert count : " + instance.Top10HighScores.Count);
                if (instance.Top10HighScores.Count > 10)
                {
                    instance.Top10HighScores.RemoveAt(10);
                }
                if (instance.Top10HighScores.Count > 0)
                {
                    instance.scoreToBeat = instance.Top10HighScores[instance.Top10HighScores.Count - 1];
                }
            }

            
            /* foreach(HighScoreData data in instance.Top10HighScores)
            {
                Debug.Log("name : " + data.HighScorePlayerName + " high score :  " + data.HighScore);
            } */


        }
        //List<HighScoreData> currentHighScoreData = new List<HighScoreData>(10);
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.Top10HighScores = instance.Top10HighScores;
        data.difficultyToggle = instance.selectedDifficultyToggle;
        /* data.HighScorePlayerName = instance.highScorePlayerName;
        data.HighScore = instance.highScore; */
        string jsonSaveData = JsonUtility.ToJson(data);
        Debug.Log("Saved game at : " + jsonSaveData);
        File.WriteAllText(Application.persistentDataPath + "/PongScoreSaveFile.json", jsonSaveData);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/PongScoreSaveFile.json";
        if (File.Exists(path))
        {
            string jsonSaveData = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonSaveData);
            if (data != null && data.Top10HighScores != null)
            {
                Debug.Log("Load high score : " + data.Top10HighScores.Count);
                if (data.Top10HighScores.Count > 0)
                {
                    instance.scoreToBeat = data.Top10HighScores[data.Top10HighScores.Count - 1];
                }
                else
                {
                    instance.scoreToBeat = new HighScoreData();
                }
                instance.Top10HighScores = data.Top10HighScores;
            }
            else
            {
                instance.Top10HighScores = new List<HighScoreData>();
                instance.scoreToBeat = new HighScoreData();
            }
            instance.selectedDifficultyToggle = data.difficultyToggle;


            /* instance.highScore = data.HighScore;
            instance.highScorePlayerName = data.HighScorePlayerName;
            Debug.Log("On load : " + data.HighScorePlayerName + data.HighScore); */
        }
    }


}
