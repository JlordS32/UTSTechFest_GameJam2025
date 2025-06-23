using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    // PROPERTIES
    [Header("Rate")]
    [SerializeField] float _interval = 3f;
    [SerializeField] int _waterPerTick = 5;
    [SerializeField] int _sunlightPerTick = 5;
    [SerializeField] int _seedPerTick = 5;

    // VARIABLES
    int _water = 0;
    int _seed = 0;
    int _sunlight = 0;
    float _timer;

    // REFERENCES
    UIManager _uiManager;

    #region UNITY_FUNCTIONS
    void Awake()
    {
        _uiManager = FindFirstObjectByType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _interval)
        {
            IncreaseRate();
            UpdateRateText();
            _timer = 0f;    // Reset Timer
        }
    }
    #endregion


    #region CLASS_METHODS
    void IncreaseRate()
    {
        _water += _waterPerTick;
        _sunlight += _sunlightPerTick;
        _seed += _seedPerTick;
    }

    void UpdateRateText()
    {
        _uiManager.UpdateWaterText(_water);
        _uiManager.UpdateSunlightText(_sunlight);
        _uiManager.UpdateSeedText(_seed);
    }

    #endregion

    #region GETTERS/SETTERS
    public int GetWater() => _water;
    public void GetWaterFromWell()
    {
        _water += 5;
        _uiManager.UpdateWaterText(_water);
    }

    public int GetWaterPerTick() => _waterPerTick;
    public void IncreaseWaterRate()
    {
        _waterPerTick *= 2;
    }

    public void SpendWater(int amount)
    {
        if (_water >= amount)
        {
            _water -= amount;
        }
    }

    public int GetSunlight() => _sunlight;
    public void SpendSunlight(int amount)
    {
        if (_sunlight >= amount)
        {
            _sunlight -= amount;
        }
    }

    public int GetSeed() => _seed;
    public void SpendSeed(int amount)
    {
        if (_seed >= amount)
        {
            _seed -= amount;
        }
    }
    #endregion
}
