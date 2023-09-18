using System;
using UnityEngine;

public class Stats : CoreComponent
{
    public event Action OnHealthZero;
    public event Action OnLifeTimeZero;
    public float MaxLifeTime { get; private set; }
    public float RemainingLifeTime { get; private set; }
    public float MaxHealth
    {
        get => GenericNotImplementedError<float>.TryGet(_maxHealth, core.transform.parent.name);
        private set => _maxHealth = value;
    }
    public float CurrentHealth
    {
        get => GenericNotImplementedError<float>.TryGet(_currentHealth, core.transform.parent.name);
        private set => _currentHealth = value;
    }

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _maxLifeTime;
    [SerializeField] private float _currentHealth;
    private float _remainingLifeTime;
    private bool _isGodMode;

    protected override void Awake()
    {
        base.Awake();

        MaxLifeTime = _maxLifeTime;
        RemainingLifeTime = _remainingLifeTime;
        _currentHealth = _maxHealth;
        _remainingLifeTime = _maxLifeTime;
        _isGodMode = false;
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (MaxLifeTime > 0)
        {
            _remainingLifeTime -= Time.deltaTime;
            RemainingLifeTime = _remainingLifeTime;
            if (_remainingLifeTime <= 0)
            {
                _remainingLifeTime = 0;
                RemainingLifeTime = _remainingLifeTime;
                OnLifeTimeZero?.Invoke();
            }
        }

        if (_isGodMode)
        {
            _currentHealth = _maxHealth;
        }
    }

    #region CurrentHealth Functions
    public void DecreaseHealth(float amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnHealthZero?.Invoke();
        }
    }

    public void IncreaseHealth(float amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, _maxHealth);
    }
    #endregion

    #region MaxHealth Functions
    public void DecreaseMaxHealth(float amount)
    {
        _maxHealth -= amount;

        if (_maxHealth <= 0)
        {
            Debug.LogError("Max health reduced to zero!!!");
        }
    }

    public void IncreaseMaxHealth(float amount)
    {
        _maxHealth += amount;
    }
    #endregion

    public void SetHealthToMax()
    {
        _currentHealth = _maxHealth;
    }
    public void GodMode(bool isGod)
    {
        _isGodMode = isGod;
    }
}
