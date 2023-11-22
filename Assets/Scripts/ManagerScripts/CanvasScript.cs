using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{   
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private GameObject StartPanel;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private GameObject PauseMenu;
    public void GameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Tutorial()
    {
        tutorialPanel.SetActive(true);
        StartPanel.SetActive(false);
    }
    public void BackButton()
    {
        tutorialPanel.SetActive(false);
        StartPanel.SetActive(true);
    }
    public void Pause()
    {
        Time.timeScale=0f;
        PauseButton.SetActive(false);
        PauseMenu.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale=1f;
        PauseButton.SetActive(true);
        PauseMenu.SetActive(false);
    }
    public void Restart()
    {   
        GameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameQuit()
    {
        Application.Quit();
        Debug.Log("Close Game");
    }
}
