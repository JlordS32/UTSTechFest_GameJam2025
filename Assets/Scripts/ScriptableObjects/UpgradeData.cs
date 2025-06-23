using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Game/Upgrade List")]
public class UpgradeData : ScriptableObject
{
    [System.Serializable]
    public class UpgradeEntry
    {
        public string UpgradeName;
        public UnityEvent OnUpgrade;
        public string UpgradeRate;
    }

    public List<UpgradeEntry> upgrades = new();

    public void ResetData()
    {
        upgrades.Clear();
    }
}
