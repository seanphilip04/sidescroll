using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMenu : MonoBehaviour
{
    public Button[] levelButtons;
    private int myLevelCurrent;
    void Start()
    {
        GameManager.Instance.CheckSaveFile();
        myLevelCurrent = GameManager.Instance.levelCurrent;
        AddChangeSceneListeners();
        DisableLockedLevel();

    }

    private void AddChangeSceneListeners()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int sceneIndexTemp = i + 2;
            levelButtons[i].onClick.AddListener(()=>GameManager.Instance.ChangeScene(sceneIndexTemp));
        }
    }

    private void DisableLockedLevel()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > myLevelCurrent)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
