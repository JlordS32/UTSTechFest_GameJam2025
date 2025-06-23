using UnityEngine;

public class Well : MonoBehaviour
{
    public CurrencyManager waterManager;


    public void WellIsPressed()
    {
        if (waterManager != null)
        {
            waterManager.GetWaterFromWell();
        }
    }

}
