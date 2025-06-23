using System;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrow : MonoBehaviour
{
    // PROPERTIES
    [Header("Base")]
    [SerializeField] PlayerData _playerData;
    [SerializeField] List<GameObject> _levelPrefabs;
    [SerializeField] Transform _spriteParent;

    [Header("Level")]
    [SerializeField] int _levelGap;

    // VARIABLES
    GameObject _currentSprite;
    CurrencyManager _currencyManager;
    int _lastKnownLevel = -1;

    void Start()
    {
        _currencyManager = FindFirstObjectByType<CurrencyManager>();
        _playerData.ResetData();
        UpdateSprite();
    }

    void Update()
    {
        if (_playerData.LVL != _lastKnownLevel)
        {
            _lastKnownLevel = _playerData.LVL;
            UpdateSprite();
        }
    }

    void UpdateSprite()
    {
        int index = Mathf.Clamp((_playerData.LVL - 1) / _levelGap, 0, _levelPrefabs.Count - 1);

        if (_currentSprite != null)
            Destroy(_currentSprite);

        _currentSprite = Instantiate(_levelPrefabs[index], _spriteParent);
    }

    void OnMouseDown()
    {
        Debug.Log("Water plant");
        WaterPlant();
    }

    void WaterPlant()
    {
        if (_currencyManager.SpendWater() && _currencyManager.SpendSeed())
        {
            _playerData.AddEXP(_currencyManager.GetConsumptionRate() * 1.5f);
        }
    }
}
