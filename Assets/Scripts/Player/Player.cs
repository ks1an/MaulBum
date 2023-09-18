using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Core Core { get; private set; }
    public float attackDamage;
    public float CurrentHealth;
    protected Stats Stats
    {
        get => _stats ??= Core.GetCoreComponent<Stats>();
    }
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _whatIsEnemy;
    private Stats _stats;


    private void Awake()
    {
        Core = GetComponentInChildren<Core>();
    }

    private void Update()
    {
        Core.LogicUpdate();

        CurrentHealth = Stats.CurrentHealth;
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit,100.0f,_whatIsEnemy) && Input.GetMouseButtonDown(0)) 
        {
            Transform objectHit = hit.transform;
            IDamageable damageable = objectHit.GetComponentInChildren<IDamageable>();
            damageable?.Damage(attackDamage);
        }
    }

    public void SetPlayerHealthToMax()
    {
       Stats.SetHealthToMax();
    }
    public void SetPlayerGodMode(bool isGod)
    {
        Stats.GodMode(isGod);
    }
}
