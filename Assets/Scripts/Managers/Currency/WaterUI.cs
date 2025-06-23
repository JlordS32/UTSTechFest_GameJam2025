using UnityEngine;
using TMPro;

public class WaterUI : MonoBehaviour
{
    public CurrencyManager waterManager;
    public TextMeshProUGUI waterText;

    // Update is called once per frame
    void Update()
    {
        waterText.text = "Water: " + waterManager.GetWater().ToString();
    }
}
