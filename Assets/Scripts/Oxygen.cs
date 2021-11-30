using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    private Slider slider;

    public void SetMaxOxygen(int maxOxygen)
    {
        slider = gameObject.GetComponent<Slider>();
        slider.maxValue = maxOxygen;
        SetOxygen(maxOxygen);
    }

    public void SetOxygen(int oxygen)
    {
        slider.value = oxygen;
    }
}
