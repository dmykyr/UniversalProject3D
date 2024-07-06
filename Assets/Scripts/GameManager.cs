using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static string currentScene;

    public static event Action<int> OnHealthAmountChanged;
    public static event Action<int> OnCoinsAmountChanged;

    public static readonly Dictionary<string, string> scenes = new()
    {
        { "Woods", "Level_1"},
        { "Islands", "Level_2"},
        { "City", "Level_3"},
        { "MainMenu", "MainMenu"},
        { "SelectLevel", "SelectLevel"},
        { "Loading", "Loading"},
    };

    private int _coins;
    private int _health;

    public int CoinsAmount {
        get => _coins;
        set { 
            OnCoinsAmountChanged?.Invoke(value);
            _coins = value;
        } 
    }

    public int HealthAmount
    {
        get => _health;
        set
        {
            OnHealthAmountChanged?.Invoke(value);
            _health = value;
        }
    }

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        CoinsAmount = 0;
        HealthAmount = 3;
    }
}
