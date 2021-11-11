using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnding : MonoBehaviour
{
    public GameObject LevelEndingUI;
    public GameObject GameEndingUI;
    public GameObject GameOverUI;
    public GameObject Joystick;
    public int currentLevel;

    public bool gameEnd = false;
    private bool gameOver = false;
    public bool GameOverCheck { get; set; }


    public void setGameOver()
    {
        gameOver = true;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        LevelEndingUI.SetActive(false);
        GameEndingUI.SetActive(false);
        GameOverUI.SetActive(false);
    }

     public void ShowMenu()
     {
        Time.timeScale = 0f;
        Joystick.SetActive(false);
        if (gameOver)
            GameOverUI.SetActive(true);
        else
        {
            GameOverCheck = true;
            if (gameEnd)
                GameEndingUI.SetActive(true);
            else
                LevelEndingUI.SetActive(true);
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene($"Level{currentLevel+1}");
    }

    public void Retry()
    {
        SceneManager.LoadScene($"Level{currentLevel}");
    }
}