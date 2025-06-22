using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void UpdateText(string value)
    {
        _text.text = value;
    }
}