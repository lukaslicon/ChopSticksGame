using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameMenuUI;

    public Button restartButton;

    public bool isGameOver = false;


    void Start()
    {
        //hides pause menu
        ToggleGameOver(false);
        restartButton.onClick.AddListener(RestartGame);
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
        Debug.Log("Game is over.");
        ToggleGameOver(true);
    }


    void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
