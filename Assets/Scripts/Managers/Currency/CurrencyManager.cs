using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [Header("Interval")]
    [SerializeField] float _interval = 3f;

    [Header("Auto Gen Rate")]
    [SerializeField] float _waterPerTick = 2f;
    [SerializeField] float _sunlightPerTick = 2f;
    [SerializeField] float _seedPerTick = 2f;

    [Header("Clicker Rate")]
    [SerializeField] float _waterPerClick = 0.5f;
    [SerializeField] float _seedPerClick = 0.5f;
    [SerializeField] float _consumptionPerClick = 1f;

    [Header("Multipliers")]
    [SerializeField] float _tickMultiplier = 1f;
    [SerializeField] float _clickMultiplier = 1f;

    [Header("Level Up Rate")]
    [SerializeField] float _waterPerClickUpgrade = 1.5f;
    [SerializeField] float _waterPerTickUpgrade = 1.5f;
    [SerializeField] float _seedPerClickUpgrade = 1.2f;
    [SerializeField] float _seedPerTickUpgrade = 1.2f;
    [SerializeField] float _consumptionRateUpgrade = 1.2f;


    float _water = 0;
    float _seed = 0;
    float _sunlight = 0;
    float _timer;

    // LEVEL TRACKING
    int _waterRateLevel = 0;
    int _seedRateLevel = 0;
    int _waterClickLevel = 0;
    int _seedClickLevel = 0;
    int _consumptionLevel = 0;

    UIManager _uiManager;

    void Awake()
    {
        _uiManager = FindFirstObjectByType<UIManager>();
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _interval)
        {
            _timer = 0f;
            IncrementCurrency();
            UpdateCurrencyText();
        }
    }

    void IncrementCurrency()
    {
        _water += _waterPerTick * _tickMultiplier;
        _sunlight += _sunlightPerTick * _tickMultiplier;
        _seed += _seedPerTick * _tickMultiplier;
    }

    void UpdateCurrencyText()
    {
        _uiManager.UpdateWaterText(_water);
        _uiManager.UpdateSunlightText(_sunlight);
        _uiManager.UpdateSeedText(_seed);
    }

    // SUNLIGHT
    public float GetSunlight() => _sunlight;
    public float GetSunLightPerTick() => _sunlightPerTick;
    public void SpendSunlight(float amount)
    {
        if (_sunlight >= amount)
            _sunlight -= amount;
    }


    // WATER
    public float GetWater() => _water;
    public float GetWaterPerTick() => _waterPerTick;
    public void GetWaterFromWell()
    {
        _water += _waterPerClick * _clickMultiplier;
        _uiManager.UpdateWaterText(_water);
    }

    public float GetWaterPerClick() => _waterPerClick;
    public void IncreaseWaterRate()
    {
        float cost = GetSunlightUpgradeCost(_waterRateLevel);
        if (_sunlight >= cost)
        {
            _sunlight -= cost;
            _waterPerTick *= _waterPerTickUpgrade;
            _waterRateLevel++;
            UpdateCurrencyText();
        }
    }

    public void IncreaseWaterPerClick()
    {
        float cost = GetSunlightUpgradeCost(_waterClickLevel);
        if (_sunlight >= cost)
        {
            _sunlight -= cost;
            _waterPerClick *= _waterPerClickUpgrade;
            _waterClickLevel++;
            UpdateCurrencyText();
        }
    }

    public bool SpendWater()
    {
        if (_water >= _consumptionPerClick)
        {
            _water -= _consumptionPerClick;
            _uiManager.UpdateWaterText(_water);
            return true;
        }
        return false;
    }

    // SEED
    public float GetSeed() => _seed;
    public void GetSeedFromCrop()
    {
        _seed += _seedPerClick * _clickMultiplier;
        _uiManager.UpdateSeedText(_seed);
    }

    public float GetSeedPerTick() => _seedPerTick;
    public void IncreaseSeedRate()
    {
        float cost = GetSunlightUpgradeCost(_seedRateLevel);
        if (_sunlight >= cost)
        {
            _sunlight -= cost;
            _seedPerTick *= _seedPerTickUpgrade;
            _seedRateLevel++;
            UpdateCurrencyText();
        }
    }


    public float GetSeedPerClick() => _seedPerClick;
    public void IncreaseSeedPerClick()
    {
        float cost = GetSunlightUpgradeCost(_seedClickLevel);
        if (_sunlight >= cost)
        {
            _sunlight -= cost;
            _seedPerClick *= _seedPerClickUpgrade;
            _seedClickLevel++;
            UpdateCurrencyText();
        }
    }

    public bool SpendSeed()
    {
        if (_seed >= _consumptionPerClick)
        {
            _seed -= _consumptionPerClick;
            UpdateCurrencyText();
            return true;
        }
        return false;
    }

    public float GetConsumptionRate() => _consumptionPerClick;
    public void IncreaseConsumptionRate()
    {
        float cost = GetSunlightUpgradeCost(_consumptionLevel);
        if (_sunlight >= cost)
        {
            _sunlight -= cost;
            _consumptionPerClick *= _consumptionRateUpgrade;
            _consumptionLevel++;
            UpdateCurrencyText();
        }
    }

    float GetSunlightUpgradeCost(int level, float baseCost = 1f, float multiplier = 1.5f)
    {
        return Mathf.Round(baseCost * Mathf.Pow(multiplier, level));
    }
}
