using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _HealthPerSegment;
    private Stats _Stats
    {
        get => _stats ??= _player.GetComponentInChildren<Stats>();
    }
    private Stats _stats;
    private RectTransform _rt;
    private Material _material;
    private float _offsetHP;
    private float _segmentAmountHP;

    private void Start()
    {
        _rt = this.GetComponent(typeof(RectTransform)) as RectTransform;
        _material = this.GetComponent<Image>().material;
    }

    private void FixedUpdate()
    {
        _segmentAmountHP = _Stats.MaxHealth / _HealthPerSegment;
        _material.SetFloat("_segmentAmount", _segmentAmountHP);

        _offsetHP = _Stats.CurrentHealth / _Stats.MaxHealth - 0.5f;
        _material.SetFloat("_offset", _offsetHP);
    }
}
