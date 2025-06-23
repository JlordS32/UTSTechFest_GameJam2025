using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class UIManager : MonoBehaviour
{
    [Header("Sidebar UI")]
    [SerializeField] UpgradePanelUI _upgradePanel;

    [Header("Currency UI")]
    [SerializeField] TextMeshProUGUI _waterTextUI;
    [SerializeField] TextMeshProUGUI _sunlightTextUI;
    [SerializeField] TextMeshProUGUI _seedTextUI;

    List<UpgradeEntry> _entries = new();

    void Start()
    {
        var currency = GetComponent<CurrencyManager>();

        AddUpgrade("Water Generation",
            () => currency.IncreaseWaterRate(),
            () => $"{NumberFormatter.Format(currency.GetWaterPerTick())}/s",
            () => $"Cost: {NumberFormatter.Format(currency.GetSunlightUpgradeCost(currency.GetWaterRateLevel()))} suns",
            () => $"Level: {currency.GetWaterRateLevel()}");

        AddUpgrade("Seed Generation",
            () => currency.IncreaseSeedRate(),
            () => $"{NumberFormatter.Format(currency.GetSeedPerTick())}/s",
            () => $"Cost: {NumberFormatter.Format(currency.GetSunlightUpgradeCost(currency.GetSeedRateLevel()))} suns",
            () => $"Level: {currency.GetSeedRateLevel()}");

        AddUpgrade("Crop Click Rate",
            () => currency.IncreaseSeedPerClick(),
            () => $"{NumberFormatter.Format(currency.GetSeedPerClick())}/click",
            () => $"Cost: {NumberFormatter.Format(currency.GetSunlightUpgradeCost(currency.GetSeedClickLevel()))} suns",
            () => $"Level: {currency.GetSeedClickLevel()}");

        AddUpgrade("Well Click Rate",
            () => currency.IncreaseWaterPerClick(),
            () => $"{NumberFormatter.Format(currency.GetWaterPerClick())}/click",
            () => $"Cost: {NumberFormatter.Format(currency.GetSunlightUpgradeCost(currency.GetWaterClickLevel()))} suns",
            () => $"Level: {currency.GetWaterClickLevel()}");

        AddUpgrade("Consumption Rate",
            () => currency.IncreaseConsumptionRate(),
            () => $"{NumberFormatter.Format(currency.GetConsumptionRate())}/s",
            () => $"Cost: {NumberFormatter.Format(currency.GetSunlightUpgradeCost(currency.GetConsumptionRateLevel()))} suns",
            () => $"Level: {currency.GetConsumptionRateLevel()}");

        _upgradePanel.Build(_entries);
    }

    void AddUpgrade(string name, UnityAction logic, Func<string> getRate, Func<string> getButtonLabel, Func<string> getLevel)
    {
        _entries.Add(new UpgradeEntry
        {
            Name = name,
            UpgradeLogic = logic,
            GetRate = getRate,
            GetButtonLabel = getButtonLabel,
            GetLevel = getLevel
        });
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
}