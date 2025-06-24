using UnityEngine;

public class Crop : MonoBehaviour
{
    [SerializeField] AudioClip _collectSeedSound;
    CurrencyManager _seedManager;

    void Awake()
    {
        _seedManager = FindFirstObjectByType<CurrencyManager>();
    }

    void OnMouseDown()
    {
        AudioManager.Instance.PlaySound(_collectSeedSound);
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
