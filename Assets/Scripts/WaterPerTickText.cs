using UnityEngine;
using TMPro;

public class WaterPerTickText : MonoBehaviour
{
    public CurrencyManager waterManager;
    public TextMeshProUGUI waterText;

    // Update is called once per frame
    void Update()
    {
        waterText.text = waterManager.GetWaterPerTick().ToString() + "w/s";
    }
}
