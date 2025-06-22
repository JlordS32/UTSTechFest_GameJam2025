using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    // PROPERTIES
    [SerializeField] InputAction _pauseButton;
    [SerializeField] GameObject _pausePanel;
    [SerializeField] GameObject _deathPanel;

    // VARIABLES
    bool _isDead;
    public bool IsDead => _isDead;

    void OnEnable()
    {
        _pauseButton.Enable();
    }

    void OnDisable()
    {
        _pauseButton.Disable();
    }

    void Update()
    {
        if (_pauseButton.WasPressedThisFrame() && !_isDead)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        AudioManager.Instance.PauseMusic();
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        _pausePanel.SetActive(!_pausePanel.activeSelf);
    }

    public void ToggleDeath()
    {
        _isDead = true;
        AudioManager.Instance.PauseMusic();
        _deathPanel.SetActive(!_pausePanel.activeSelf);
    }
}