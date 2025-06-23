using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    TextMeshProUGUI _upgradeNameText;
    TextMeshProUGUI _rateText;
    Button _upgradeButton;

    public void Setup(string upgradeName, string rateText, UnityEngine.Events.UnityAction onClick)
    {
        if (_upgradeNameText == null || _rateText == null || _upgradeButton == null)
        {
            var texts = GetComponentsInChildren<TextMeshProUGUI>(true);
            foreach (var text in texts)
            {
                if (text.name == "Upgrade Name") _upgradeNameText = text;
                else if (text.name == "Rate") _rateText = text;
            }

            _upgradeButton = GetComponentInChildren<Button>(true);
        }

        _upgradeNameText.text = upgradeName;
        _rateText.text = rateText;
        _upgradeButton.onClick.RemoveAllListeners();
        _upgradeButton.onClick.AddListener(onClick);
    }
}
