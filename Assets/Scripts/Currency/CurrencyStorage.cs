using System;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyStorage : MonoBehaviour
{
    // VARIABLES
    Dictionary<CurrencyType, Storage> _storage = new();

    // UNITY FUNCTIONS
    void Awake()
    {
        foreach (CurrencyType type in Enum.GetValues(typeof(CurrencyType)))
            _storage[type] = new Storage();
    }

    // GETTERS & SETTER
    public void Add(CurrencyType type, float amount) => _storage[type].Add(amount);
    public bool Spend(CurrencyType type, float amount) => _storage[type].Spend(amount);
    public float Get(CurrencyType type) => _storage[type].Value;

    // RESET
    public void ResetAll()
    {
        foreach (CurrencyType type in Enum.GetValues(typeof(CurrencyType)))
            _storage[type] = new Storage();
    }
}
