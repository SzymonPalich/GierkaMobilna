using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{
    public int levelCount = 6;
    void Start()
    {
        Saves saveManager = new Saves();
        for (int i = 2; i <= levelCount; i++)
        {
            if (saveManager.CheckIfCompleted(i))
            {
                GameObject.Find($"Level{i}").GetComponent<Button>().interactable = true;
            }
        }
    }
}
