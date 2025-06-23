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

    void Start()
    {
        _playerData.ResetData();
        UpdateSprite();
    }

    public void OnTest()
    {
        _playerData.AddEXP(10);
        Debug.Log($"LVL: {_playerData.LVL} EXP: {_playerData.EXP}");
        Debug.Log($"ATK: {_playerData.ATK} HP: {_playerData.HP}");

        UpdateSprite();
    }

    void UpdateSprite()
    {
        int index = Mathf.Clamp((_playerData.LVL - 1) / _levelGap, 0, _levelPrefabs.Count - 1);

        if (_currentSprite != null)
            Destroy(_currentSprite);

        _currentSprite = Instantiate(_levelPrefabs[index], _spriteParent);
    }
}
