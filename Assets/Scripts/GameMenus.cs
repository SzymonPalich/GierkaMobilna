using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenus : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject levelEndingUI;
    public GameObject gameEndingUI;
    public GameObject gameOverUI;

    public GameObject joystick;
    public GameObject joyButton;

    public int currentLevel;
    private int nextLevel;
    public bool gameEnd = false;

    protected bool isPaused = false;
    public bool IsPaused { get; }

    private void Start()
    {
        Time.timeScale = 1f;
        nextLevel = currentLevel + 1;
        pauseMenuUI.SetActive(false);
        levelEndingUI.SetActive(false);
        gameEndingUI.SetActive(false);
        gameOverUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                HidePauseMenu();
            }
            else
            {
                ShowPauseMenu();
            }
        }
    }

    public void ShowGameOver()
    {
        Pause();
        gameOverUI.SetActive(true);
    }

    public void ShowLevelEndUI()
    {
        Saves saveManager = new Saves();
        if (!saveManager.CheckIfCompleted(nextLevel))
        {
            saveManager.SetComplete(nextLevel);
        }

        Pause();
        if (gameEnd)
        {
            gameEndingUI.SetActive(true);
        }
        else
        {
            levelEndingUI.SetActive(true);
        }
    }
    public void ShowPauseMenu()
    {
        pauseMenuUI.SetActive(true);
        Pause();
    }

    public void HidePauseMenu()
    {
        pauseMenuUI.SetActive(false);
        Resume();
    }

    private void Pause()
    {
        isPaused = true;
        joystick.SetActive(false);
        joyButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        isPaused = false;
        joystick.SetActive(true);
        joyButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene($"Level{nextLevel}");
    }

    public void Retry()
    {
        SceneManager.LoadScene($"Level{currentLevel}");
    }
}
