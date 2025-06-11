using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

[System.Serializable]
public class LevelData
{
    public int level;
}

public class GameManager : MonoBehaviour
{
    #region GameManager
    public static GameManager Instance;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad (gameObject);
        }
        else
        {
            Destroy (gameObject);
        }
    }
    #endregion

    #region  GameManagement
    public bool isPaused;
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
    #endregion


    
    #region LevelManager
    public int levelCurrent;
    
    public void CheckSaveFile()
    {
        if (File.Exists(Application.dataPath + "/Level.json"))
        {
            LoadLevel();
        }
        else
        {
             SaveLevel();
        }
    }
    private void SaveLevel()
    {
        LevelData levelData = new LevelData();
        levelData.level = levelCurrent;
        string json = JsonUtility.ToJson(levelData);
        File.WriteAllText(Application.dataPath + "/Level.json", json);
    }

    private void LoadLevel()
    {
        string json;
        json = File.ReadAllText(Application.dataPath + "/Level.json");
        LevelData levelData = JsonUtility.FromJson<LevelData>(json);
        levelCurrent = levelData.level;
    }

    public void ChangeLevel(int newLevelUnlocked)
    {
        levelCurrent = newLevelUnlocked;
        SaveLevel();
    }

    public void ResetLevel()
    {
        levelCurrent = 0;
        SaveLevel();
    }
    #endregion
    // public void GameManagerCheck()
    // {
    //     Debug.Log(Instance.name + "LIBERTY HAS ARRIVED");
    // }
}