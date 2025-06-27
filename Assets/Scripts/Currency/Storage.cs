[System.Serializable]
public struct Storage
{
    public float Value;

    public void Add(float amount) => Value += amount;
    public bool Spend(float amount)
    {
        if (Value >= amount)
        {
            Value -= amount;
            return true;
        }

        return false;
    }
}