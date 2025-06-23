using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] int water = 0;
    [SerializeField] int waterPerTick = 5;

    [SerializeField] int sunlight = 0;
    [SerializeField] int sunlightPerTick = 5;

    [SerializeField] int seed = 0;
    [SerializeField] int seedPerTick = 5;

    [SerializeField] float interval = 3f;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            water += waterPerTick;
            sunlight += sunlightPerTick;
            seed += seedPerTick;
            timer = 0f;
        }
    }

    public int GetWater() => water;
    public bool SpendWater(int amount)
    {
        if (water >= amount)
        {
            water -= amount;
            return true;
        }

        return false;
    }

    public int GetSunlight() => sunlight;
    public bool SpendSunlight(int amount)
    {
        if (sunlight >= amount)
        {
            sunlight -= amount;
            return true;
        }

        return false;
    }

    public int GetSeed() => seed;
    public bool SpendSeed(int amount)
    {
        if (seed >= amount)
        {
            seed -= amount;
            return true;
        }
        return false;
    }
}
