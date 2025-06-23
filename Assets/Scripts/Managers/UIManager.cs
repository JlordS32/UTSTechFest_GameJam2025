using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [Header("Sidebar UI")]
    [SerializeField] UpgradeData _myUpgradeData;
    [SerializeField] UpgradePanelUI _upgradePanel;

    [Header("Currency UI")]
    [SerializeField] TextMeshProUGUI _waterTextUI;
    [SerializeField] TextMeshProUGUI _sunlightTextUI;
    [SerializeField] TextMeshProUGUI _seedTextUI;

    void Start()
    {
        CurrencyManager _currencyManager = GetComponent<CurrencyManager>();
        if (_currencyManager == null)
        {
            Debug.LogError("CurrencyManager is missing on UIManager GameObject!");
            return;
        }

        AddUpgrade("Water Upgrade", () =>
        {
            _currencyManager.IncreaseWaterRate();
        });
        AddUpgrade("Dowee", () =>
        {
            Debug.Log("Hello World");
        });
        AddUpgrade("Dowee", () =>
        {
            Debug.Log("Hello World");
        });
        AddUpgrade("Dowee", () =>
        {
            Debug.Log("Hello World");
        });
        AddUpgrade("Dowee", () =>
        {
            Debug.Log("Hello World");
        });
        AddUpgrade("Dowee", () =>
        {
            Debug.Log("Hello World");
        });
        AddUpgrade("Dowee", () =>
        {
            Debug.Log("Hello World");
        });
        AddUpgrade("Dowee", () =>
        {
            Debug.Log("Hello World");
        });
        AddUpgrade("Dowee", () =>
        {
            Debug.Log("Hello World");
        });

        _upgradePanel?.Refresh();
    }

    public void AddUpgrade(string name, UnityAction action)
    {
        var entry = new UpgradeData.UpgradeEntry
        {
            UpgradeName = name,
            OnUpgrade = new UnityEvent()
        };

        entry.OnUpgrade.AddListener(action);
        _myUpgradeData.upgrades.Add(entry);
    }

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

    void OnDestroy()
    {
        _myUpgradeData.ResetData();
    }
}