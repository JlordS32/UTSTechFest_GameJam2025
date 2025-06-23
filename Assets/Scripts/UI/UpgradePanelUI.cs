using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelUI : MonoBehaviour
{
    [SerializeField] UpgradeData _upgrades;
    [SerializeField] GameObject _upgradeComponent;

    void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        // Destroy any existing UI elements.
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Add new ones
        foreach (var data in _upgrades.upgrades)
        {
            GameObject go = Instantiate(_upgradeComponent, transform);
            go.GetComponent<UpgradeUI>().Setup(data.UpgradeName, data.OnUpgrade.Invoke);
        }
    }
}
