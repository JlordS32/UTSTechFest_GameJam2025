using UnityEngine;

public class Well : MonoBehaviour
{
    [SerializeField] AudioClip _collectWaterSound;
    CurrencyManager _waterManager;

    void Awake()
    {
        _waterManager = FindFirstObjectByType<CurrencyManager>();
    }

    void OnMouseDown()
    {
        AudioManager.Instance.PlaySound(_collectWaterSound);
        WellIsPressed();
    }

    public void WellIsPressed()
    {
        if (_waterManager != null)
        {
            _waterManager.GetWaterFromWell();
        }
    }
}
