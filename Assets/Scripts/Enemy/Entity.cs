using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Core Core { get; private set; }
    protected Stats Stats
    {
        get => _stats ??= Core.GetCoreComponent<Stats>();
    }

    [SerializeField] private float attackDamage;
    private GameController _gameController;
    private Stats _stats;
    private IDamageable _playerDamageable;

    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();
        _playerDamageable = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<IDamageable>();
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public virtual void Update()
    {
        Core.LogicUpdate();
    }
    public virtual void OnDestroy()
    {
        if (Stats.RemainingLifeTime <= 0)
        {
            _playerDamageable?.Damage(attackDamage);
        }
        else if (Stats.CurrentHealth <= 0)
        {
            _gameController.IncreaseScore(Stats.MaxHealth);
        }
    }
}
