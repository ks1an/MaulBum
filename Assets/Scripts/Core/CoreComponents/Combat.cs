using UnityEngine;

public class Combat : CoreComponent, IDamageable
{
    [SerializeField] private GameObject _damageParticles;
    private ParticleManager _ParticleManager => _particleManager ? _particleManager : core.GetCoreComponent<ParticleManager>();
    private ParticleManager _particleManager;
    private Stats _Stats
    {
        get => _stats ??= core.GetCoreComponent<Stats>();
    }
    private Stats _stats;

    public void Damage(float amount)
    {
        _Stats?.DecreaseHealth(amount);
        _ParticleManager?.StartParticlesWithRandomRotation(_damageParticles);
    }
}