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

    void InitialUpgrades()
    {
        CurrencyManager _currencyManager = GetComponent<CurrencyManager>();
        if (_currencyManager == null)
        {
            Debug.LogError("CurrencyManager is missing on UIManager GameObject!");
            return;
        }

        AddUpgrade("Water Generation", () =>
        {
            _currencyManager.IncreaseWaterRate();
            _upgradePanel?.Refresh();
        }, $"{_currencyManager.GetWaterPerTick()}/s");

        AddUpgrade("Seed Generation", () =>
        {
            _currencyManager.IncreaseSeedRate();
        }, $"{_currencyManager.GetSeedPerTick()}/s");

        AddUpgrade("Crop Click Rate", () =>
        {
            _currencyManager.IncreaseSeedPerClick();
        }, $"{_currencyManager.GetSeedPerClick()}/click");

        AddUpgrade("Well Click Rate", () =>
        {
            _currencyManager.IncreaseWaterPerClick();
        }, $"{_currencyManager.GetWaterPerClick()}/click");

        AddUpgrade("Consumption Rate", () =>
        {
            _currencyManager.IncreaseConsumptionRate();
        }, $"{_currencyManager.GetConsumptionRate()}/s");
    }

    void Start()
    {
        InitialUpgrades();
        _upgradePanel?.Refresh();
    }

    public void AddUpgrade(string name, UnityAction action, string rateName)
    {
        var entry = new UpgradeData.UpgradeEntry
        {
            UpgradeName = name,
            OnUpgrade = new UnityEvent(),
            UpgradeRate = rateName
        };

        entry.OnUpgrade.AddListener(action);
        _myUpgradeData.upgrades.Add(entry);
    }

    public void UpdateWaterText(float value)
    {
        _waterTextUI.text = $"Water: {value:F2}";
    }

    public void UpdateSunlightText(float value)
    {
        _sunlightTextUI.text = $"Sunlight: {value:F2}";
    }

    public void UpdateSeedText(float value)
    {
        _seedTextUI.text = $"Seed: {value:F2}";
    }

    void OnDestroy()
    {
        _myUpgradeData.ResetData();
    }
}