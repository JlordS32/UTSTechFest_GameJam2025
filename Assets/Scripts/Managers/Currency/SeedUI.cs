using UnityEngine;
using TMPro;

public class Seed : MonoBehaviour
{
    public CurrencyManager seedManager;
    public TextMeshProUGUI seedText;

    // Update is called once per frame
    void Update()
    {
        seedText.text = "Seed: " + seedManager.GetSeed().ToString();
    }
}
