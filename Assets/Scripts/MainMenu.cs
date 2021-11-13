using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenGithubLink()
    {
        Application.OpenURL("https://github.com/MagicznySzymcio");
    }
}
