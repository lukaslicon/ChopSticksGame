using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameMenuUI;

    public Button restartButton;
    public Button quitButton;

    public bool isGameOver = false;


    void Start()
    {
        //hides pause menu
        ToggleGameOver(false);
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Update()
    {
            if (isGameOver)
            {
                GameOver();
            }
    }

    void ToggleGameOver(bool pause)
    {
        gameMenuUI.SetActive(pause);
        Time.timeScale = pause ? 0 : 1;
    }

    void GameOver()
    {
        ToggleGameOver(true);
    }

    void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void QuitGame()
    {
        Application.Quit();

    }
}
