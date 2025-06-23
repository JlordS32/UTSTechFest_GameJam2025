using UnityEngine;
using TMPro;

public class Well : MonoBehaviour
{
    public CurrencyManager waterManager;


    public void Pressed()
    {
        if (waterManager != null)
        {
            waterManager.GetWaterFromWell();
        }
    }

}
