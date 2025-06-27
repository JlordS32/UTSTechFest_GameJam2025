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

    [Header("Level UI")]
    [SerializeField] TextMeshProUGUI _levelTextUI;
    [SerializeField] TextMeshProUGUI _expTextUI;

    // VARIABLES
    Dictionary<CurrencyType, TextMeshProUGUI> _currencyTexts = new();
    List<UpgradeEntry> _entries = new();

    void Awake()
    {
        _currencyTexts[CurrencyType.Water] = _waterTextUI;
        _currencyTexts[CurrencyType.Sunlight] = _sunlightTextUI;
        _currencyTexts[CurrencyType.Seed] = _seedTextUI;
    }

    void Start()
    {
        var currency = GetComponent<CurrencyManager>();

        // AddUpgrade("Water Generation",
        //     () => currency.IncreaseWaterRate(),
        //     () => $"{NumberFormatter.Format(currency.GetWaterPerTick())}/s",
        //     () => $"Cost: {NumberFormatter.Format(currency.GetSunlightUpgradeCost(currency.GetWaterRateLevel()))} suns",
        //     () => $"Level: {currency.GetWaterRateLevel()}");

        // AddUpgrade("Seed Generation",
        //     () => currency.IncreaseSeedRate(),
        //     () => $"{NumberFormatter.Format(currency.GetSeedPerTick())}/s",
        //     () => $"Cost: {NumberFormatter.Format(currency.GetSunlightUpgradeCost(currency.GetSeedRateLevel()))} suns",
        //     () => $"Level: {currency.GetSeedRateLevel()}");

        // AddUpgrade("Crop Click Rate",
        //     () => currency.IncreaseSeedPerClick(),
        //     () => $"{NumberFormatter.Format(currency.GetSeedPerClick())}/click",
        //     () => $"Cost: {NumberFormatter.Format(currency.GetSunlightUpgradeCost(currency.GetSeedClickLevel()))} suns",
        //     () => $"Level: {currency.GetSeedClickLevel()}");

        // AddUpgrade("Well Click Rate",
        //     () => currency.IncreaseWaterPerClick(),
        //     () => $"{NumberFormatter.Format(currency.GetWaterPerClick())}/click",
        //     () => $"Cost: {NumberFormatter.Format(currency.GetSunlightUpgradeCost(currency.GetWaterClickLevel()))} suns",
        //     () => $"Level: {currency.GetWaterClickLevel()}");

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


    public void UpdateCurrencyText(CurrencyType type, float value)
    {
        if (_currencyTexts.TryGetValue(type, out var uiText))
            uiText.text = $"{type}: {NumberFormatter.Format(value)}";
    }

    public void UpdateLevelText(int value)
    {
        _levelTextUI.text = $"Level: {NumberFormatter.Format(value)}";
    }

    public void UpdateExpText(float value, float cap)
    {
        _expTextUI.text = $"EXP: {NumberFormatter.Format(value)} / {NumberFormatter.Format(cap)}";
    }
}