using UnityEngine;

public class PlantGrow : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;

    public void OnTest()
    {
        _playerData.AddEXP(10);
        Debug.Log($"LVL: {_playerData.LVL} EXP: {_playerData.EXP}");
        Debug.Log($"ATK: {_playerData.ATK} HP: {_playerData.HP}");
    }
}
