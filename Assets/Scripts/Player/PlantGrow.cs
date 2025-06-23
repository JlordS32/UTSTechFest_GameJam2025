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

    [Header("Audio")]
    [SerializeField] AudioClip _levelUpSound;
    [SerializeField] AudioClip _growUpSound;

    // VARIABLES
    GameObject _currentSprite;
    CurrencyManager _currencyManager;
    int _lastKnownLevel = -1;
    int _lastKnownIndex = -1;

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
            if (_lastKnownLevel > 1) 
                AudioManager.Instance.PlaySound(_levelUpSound);
            _lastKnownLevel = _playerData.LVL;
            UpdateSprite();
        }
    }

    void UpdateSprite()
    {
        int index = Mathf.Clamp((_playerData.LVL - 1) / _levelGap, 0, _levelPrefabs.Count - 1);
        _lastKnownIndex = index;

        if (index != _lastKnownIndex && index > 0)
        {
            AudioManager.Instance.PlaySound(_growUpSound);
        }

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
