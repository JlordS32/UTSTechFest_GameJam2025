using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _waterTextUI;
    [SerializeField] private TextMeshProUGUI _sunlightTextUI;
    [SerializeField] private TextMeshProUGUI _seedTextUI;

    public void UpdateWaterText(int value)
    {
        _waterTextUI.text = $"Water: {value}";
    }

    public void UpdateSunlightText(int value)
    {
        _sunlightTextUI.text = $"Sunlight: {value}";
    }

    public void UpdateSeedText(int value)
    {
        _seedTextUI.text = $"Seed: {value}";
    }
}