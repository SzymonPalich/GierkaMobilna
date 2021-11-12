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
    public bool gameEnd = false;

    protected bool isPaused = false;
    public bool IsPaused { get; }

    private void Start()
    {
        Time.timeScale = 1f;

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
                Resume();
            else
                Pause();
        }
    }

    public void ShowGameOver()
    {
        Pause();
        gameOverUI.SetActive(true);
    }

    public void ShowLevelEndUI()
    {
        Pause();
        if (gameEnd) gameEndingUI.SetActive(true);
        else levelEndingUI.SetActive(true);

    }
    protected void ShowPauseMenu()
    {
        Pause();
        pauseMenuUI.SetActive(true);
    }

    protected void HidePauseMenu()
    {
        Resume();
        pauseMenuUI.SetActive(false);
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
        SceneManager.LoadScene($"Level{currentLevel + 1}");
    }

    public void Retry()
    {
        SceneManager.LoadScene($"Level{currentLevel}");
    }
}
