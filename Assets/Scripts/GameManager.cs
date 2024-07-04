using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static event Action<int> OnHealthAmountChanged;
    public static event Action<int> OnCoinsAmountChanged;

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
