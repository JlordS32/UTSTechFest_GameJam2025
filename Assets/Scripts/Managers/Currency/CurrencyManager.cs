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
    UIManager _uiManager;

    private void Awake()
    {
        _uiManager = FindFirstObjectByType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            water += waterPerTick;
            sunlight += sunlightPerTick;
            seed += seedPerTick;
            _uiManager.UpdateWaterText(water);
            _uiManager.UpdateSunlightText(sunlight);
            _uiManager.UpdateSeedText(seed);
            timer = 0f;
        }
    }

    public int GetWater() => water;
    public bool GetWaterFromWell()
    {
        water += 5;
        _uiManager.UpdateWaterText(water);
        return true;
    }

    public int GetWaterPerTick() => waterPerTick;
    public bool ChangeWaterIncrement(int amount)
    {
        waterPerTick += amount;
        return true;

    }
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
