using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowLogo : MonoBehaviour
{
    private Image logo;
    private Color color;
    void Start()
    {
        logo = GetComponent<Image>();
        color = logo.color;
    }

    void Update()
    {
        if (color.a <= 1.0f)
        {
            color.a += 0.005f;
            logo.color = color;
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
