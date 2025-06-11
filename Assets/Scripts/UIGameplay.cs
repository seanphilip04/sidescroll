using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour
{
    [Header ("Gameplay Buttons")]
    public Button buttonPause;
    public Button buttonResume;
    public Button buttonMenu;

    private void Start()
    {
        buttonMenu.onClick.AddListener(()=>GameManager.Instance.ChangeScene(0));
        buttonPause.onClick.AddListener(HandleButtonClick);
        buttonResume.onClick.AddListener(HandleButtonClick);
        buttonResume.gameObject.SetActive(false);
        buttonPause.gameObject.SetActive(true);
    }

    private void HandleButtonClick()
    {
        if (GameManager.Instance.isPaused)
        {
            GameManager.Instance.Resume();
            buttonResume.gameObject.SetActive(false);
            buttonPause.gameObject.SetActive(true);
        }
        else
        {
            GameManager.Instance.Pause();
            buttonResume.gameObject.SetActive(true);
            buttonPause.gameObject.SetActive(false);
        }
    }
}
