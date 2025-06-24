using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game/PlayerData")]
public class PlayerData : ScriptableObject
{
    static readonly float EXP_LEVEL_UP_RATE = 2.5f;
    static readonly int ATK_LEVEL_UP_RATE = 2;
    static readonly int HP_LEVEL_UP_RATE = 5;
    static readonly float BASE_EXP = 10;

    public int LVL = 1;
    public float EXP = 0f;
    public int HP = 100;
    public int ATK = 10;

    public void ResetData()
    {
        LVL = 1;
        EXP = 0f;
        HP = 100;
        ATK = 10;
    }

    public void AddEXP(float value)
    {
        EXP += value;
        CheckLevelUp();
    }

    public void CheckLevelUp()
    {
        float requiredExp = GetRequiredEXP(LVL);
        while (EXP >= requiredExp)
        {
            EXP -= requiredExp;
            LVL++;
            ATK += ATK_LEVEL_UP_RATE;
            HP += HP_LEVEL_UP_RATE;
            requiredExp = GetRequiredEXP(LVL);
        }
    }

    public float GetRequiredEXP(int level)
    {
        return level * EXP_LEVEL_UP_RATE * BASE_EXP;
    }
}