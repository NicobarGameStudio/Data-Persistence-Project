using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsUIHandler : MonoBehaviour
{
    public ToggleGroup difficultyToggleGroup;
    // Start is called before the first frame update
    void Start()
    {
       Toggle[] toggles = difficultyToggleGroup.GetComponentsInChildren<Toggle>();
        Debug.Log("settings to start : " + toggles.Length);
        foreach (Toggle t in toggles)
        {
            
            if (HighScoreManager.instance.selectedDifficultyToggle == t.gameObject.name)
            {
                t.isOn = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void OpenStartMenu()
    {
        Toggle[] toggles = difficultyToggleGroup.GetComponentsInChildren<Toggle>();
        Debug.Log("settings to start : " + toggles.Length);
        foreach (Toggle t in toggles)
        {
            Debug.Log(t);
            if (t.isOn)
            {
                HighScoreManager.instance.selectedDifficultyToggle = t.gameObject.name;
            }
        }
        //int selectDifficultyIndex = difficultyToggleGroup.ActiveToggles();
        HighScoreManager.instance.SaveHighScore();
        SceneManager.LoadScene(0);
    }
}
