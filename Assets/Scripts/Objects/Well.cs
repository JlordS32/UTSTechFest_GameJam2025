using UnityEngine;

public class Well : MonoBehaviour
{
    CurrencyManager _waterManager;

    void Awake()
    {
        _waterManager = FindFirstObjectByType<CurrencyManager>();
    }

    void OnMouseDown()
    {
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
