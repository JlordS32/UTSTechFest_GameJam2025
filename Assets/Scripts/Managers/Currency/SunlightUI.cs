using UnityEngine;
using TMPro;

public class SunlightUI : MonoBehaviour
{
    public CurrencyManager sunlightManager;
    public TextMeshProUGUI sunlightText;

    // Update is called once per frame
    void Update()
    {
        sunlightText.text = "Sunlight: " + sunlightManager.GetSunlight().ToString();
    }
}
