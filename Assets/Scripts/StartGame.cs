using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class StartGame : MonoBehaviour
{
    public GameObject gameMenuUI;

    public Button startButton;
    public Button quitButton;
    public bool isStarted = false;
    void Start()
    {
        //hides pause menu
        ToggleStartMenu(true);
        startButton.onClick.AddListener(StartGameButton);
        quitButton.onClick.AddListener(QuitGame);
    }


    void ToggleStartMenu(bool pause)
    {
        gameMenuUI.SetActive(pause);
        Time.timeScale = pause ? 0 : 1;
    }

    void StartGameButton()
    {
        isStarted = true;
        ToggleStartMenu(false);
    }
    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

}
