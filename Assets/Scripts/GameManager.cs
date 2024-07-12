using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static string currentScene;

    public static event Action<int> OnHealthAmountChanged;
    public static event Action OnCharacterDead;
    public static event Action<int> OnCoinsAmountChanged;

    public static readonly Dictionary<string, string> scenes = new()
    {
        { "Woods", "Level_1"},
        { "Islands", "Level_2"},
        { "City", "Level_3"},
        { "MainMenu", "MainMenu"},
        { "SelectLevel", "SelectLevel"},
        { "Loading", "Loading"},
        { "Shop", "Shop"},
    };

    // resources that changes while player pass level
    private int _currentCoins;
    private int _currentHealth;

    // general resources that do not directly changes on passing level
    private int _playerCoins;
    private int _playerHealth;

    public int CoinsAmount {
        get => _currentCoins;
        set { 
            OnCoinsAmountChanged?.Invoke(value);
            _currentCoins = value;
        } 
    }

    public int HealthAmount
    {
        get => _currentHealth;
        set
        {
            OnHealthAmountChanged?.Invoke(value);
            _currentHealth = value;
            if (_currentHealth <= 0) OnCharacterDead.Invoke();
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        CoinsAmount = 0;
        HealthAmount = 100;

        _playerCoins = 0;
        _playerHealth = 100;
    }

    public void SaveCurrentResourceValues()
    {
        _playerCoins = _currentCoins;
        _playerHealth = _currentHealth;
    }

    public void RestoreCurrentResourceValues()
    {
        _currentCoins = _playerCoins;
        _currentHealth = _playerHealth;
    }
}
