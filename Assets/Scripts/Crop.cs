using UnityEngine;

public class Crop : MonoBehaviour
{
    public CurrencyManager seedManager;


    public void CropIsPressed()
    {
        if (seedManager != null)
        {
            seedManager.GetSeedFromCrop();
        }
    }

}
