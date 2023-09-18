using System;
using UnityEngine;

public class Death : CoreComponent
{
    [SerializeField] private GameObject[] _deathHealthParticles;
    [SerializeField] private GameObject[] _deathLifeTimeParticles;

    private ParticleManager _ParticleManager => _particleManager ? _particleManager : core.GetCoreComponent<ParticleManager>();
    private ParticleManager _particleManager;
    private Stats _Stats => _stats ? _stats : core.GetCoreComponent<Stats>();
    private Stats _stats;

    public void DieHealth()
    {
        if (core.transform.parent.name != "Player")
        {
            foreach (var particle in _deathHealthParticles)
            {
                _ParticleManager.StartParticles(particle);
            }
            Destroy(core.transform.parent.gameObject);
        }
    }
    public void DieLifeTime()
    {
        foreach (var particle in _deathLifeTimeParticles)
        {
            _ParticleManager.StartParticles(particle);
        }
        Destroy(core.transform.parent.gameObject);
    }

    private void OnEnable()
    {
        _Stats.OnHealthZero += DieHealth;
        _Stats.OnLifeTimeZero += DieLifeTime;
    }

    private void OnDisable()
    {
        _Stats.OnHealthZero -= DieHealth;
        _Stats.OnLifeTimeZero -= DieLifeTime;
    }
}