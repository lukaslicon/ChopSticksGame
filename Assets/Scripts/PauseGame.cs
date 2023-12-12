using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class PauseGame : MonoBehaviour
{
    public GameObject gameMenuUI;

    public Button resumeButton;
    public Button restartButton;
    public Button quitButton;

    public bool isPaused = false;


    void Start()
    {
        //hides pause menu
        TogglePause(false);
        resumeButton.onClick.AddListener(ResumeGame);
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGameMenu();
        }
    }

    void TogglePause(bool pause)
    {
        gameMenuUI.SetActive(pause);
        Time.timeScale = pause ? 0 : 1;
        isPaused = pause;
    }
    void PauseGameMenu()
    {
        TogglePause(true);
    }
    void ResumeGame()
    {
        TogglePause(false);
    }

    void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
