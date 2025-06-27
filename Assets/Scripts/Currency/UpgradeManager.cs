using UnityEngine;
using System;

public class UpgradeManager : MonoBehaviour
{
    // PROPERTIES
    [SerializeField] float _baseCost = 2f;
    [SerializeField] float _costMultiplier = 1.5f;

    // REFERENCES
    CurrencyStorage _storage;

    // UNITY FUNCTIONS
    void Awake() => _storage = GetComponent<CurrencyStorage>();

    // CUSTOM FUNCTIONS HERE
    // ---------------------
    float GetCost(int level) => Mathf.Round(_baseCost * Mathf.Pow(_costMultiplier, level));

    public bool Upgrade(CurrencyType costType, int level, Action upgradeAction, out float spent)
    {
        float cost = GetCost(level);
        spent = cost;

        if (_storage.Spend(costType, cost))
        {
            upgradeAction?.Invoke();
            return true;
        }

        return false;
    }
}
