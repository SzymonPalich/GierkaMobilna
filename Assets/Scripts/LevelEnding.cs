using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnding : MonoBehaviour
{
    public GameObject LevelEndingUI;
    public GameObject GameEndingUI;
    public GameObject Joystick;
    public int nextLevel;
    public bool gameEnd;

    private void Start()
    {
        Time.timeScale = 1f;
        LevelEndingUI.SetActive(false);
        GameEndingUI.SetActive(false);
    }

     public void ShowMenu()
     {
        Time.timeScale = 0f;
        Joystick.SetActive(false);
        if (gameEnd)
            GameEndingUI.SetActive(true);
        else
            LevelEndingUI.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene($"Level{nextLevel}");
    }
}