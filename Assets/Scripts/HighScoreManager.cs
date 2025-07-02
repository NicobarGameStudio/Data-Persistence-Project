using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager instance;
    public string currentPlayerName;
    public int highScore;
    public string highScorePlayerName;

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

    class SaveData
    {
        public string HighScorePlayerName;
        public int HighScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.HighScorePlayerName = instance.highScorePlayerName;
        data.HighScore = instance.highScore;
        string jsonSaveData = JsonUtility.ToJson(data);
        Debug.Log("Saved game at : " + Application.persistentDataPath + "/PongSaveFile.json");
        File.WriteAllText(Application.persistentDataPath + "/PongSaveFile.json", jsonSaveData);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/PongSaveFile.json";
        if (File.Exists(path))
        {
            string jsonSaveData = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonSaveData);
            instance.highScore = data.HighScore;
            instance.highScorePlayerName = data.HighScorePlayerName;
            Debug.Log("On load : " + data.HighScorePlayerName + data.HighScore);
        }
    }

}
