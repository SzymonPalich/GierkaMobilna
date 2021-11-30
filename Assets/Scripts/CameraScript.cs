using UnityEngine;

public class CameraScript : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        Screen.SetResolution(Screen.width, Screen.height, true);

    }
}
