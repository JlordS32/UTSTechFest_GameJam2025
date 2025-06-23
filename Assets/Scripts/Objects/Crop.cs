using UnityEngine;

public class Crop : MonoBehaviour
{
    CurrencyManager _seedManager;

    void Awake()
    {
        _seedManager = FindFirstObjectByType<CurrencyManager>();
    }

    void OnMouseDown()
    {
        CropIsPressed();
    }

    public void CropIsPressed()
    {
        if (_seedManager != null)
        {
            _seedManager.GetSeedFromCrop();
        }
    }
}
