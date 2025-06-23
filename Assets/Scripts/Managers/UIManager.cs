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
            () => $"{currency.GetWaterPerTick():F1}/s");

        AddUpgrade("Seed Generation",
            () => currency.IncreaseSeedRate(),
            () => $"{currency.GetSeedPerTick():F1}/s");

        AddUpgrade("Crop Click Rate",
            () => currency.IncreaseSeedPerClick(),
            () => $"{currency.GetSeedPerClick():F1}/click");

        AddUpgrade("Well Click Rate",
            () => currency.IncreaseWaterPerClick(),
            () => $"{currency.GetWaterPerClick():F1}/click");

        AddUpgrade("Consumption Rate",
            () => currency.IncreaseConsumptionRate(),
            () => $"{currency.GetConsumptionRate():F1}/s");

        _upgradePanel.Build(_entries);
    }


    void AddUpgrade(string name, UnityAction logic, Func<string> getRate)
    {
        _entries.Add(new UpgradeEntry
        {
            Name = name,
            UpgradeLogic = logic,
            GetRate = getRate
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