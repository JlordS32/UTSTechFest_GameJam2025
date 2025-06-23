using UnityEngine;

public class Well : MonoBehaviour
{
    public CurrencyManager waterManager;
    public void Pressed()
    {

        waterManager.ChangeWaterIncrement(5);
    }
}
