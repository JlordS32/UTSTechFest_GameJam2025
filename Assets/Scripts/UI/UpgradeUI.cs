using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    TextMeshProUGUI _upgradeNameText;
    Button _upgradeButton;

    public void Setup(string upgradeName, UnityEngine.Events.UnityAction onClick)
    {
        if (_upgradeNameText == null)
            _upgradeNameText = GetComponentInChildren<TextMeshProUGUI>(true);
        if (_upgradeButton == null)
            _upgradeButton = GetComponentInChildren<Button>(true);

        _upgradeNameText.text = upgradeName;
        _upgradeButton.onClick.RemoveAllListeners();
        _upgradeButton.onClick.AddListener(onClick);
    }
}
