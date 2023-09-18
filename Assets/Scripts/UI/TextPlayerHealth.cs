using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPlayerHealth : MonoBehaviour
{
    private TMP_Text _healthText;
    private Player _player;

    private void Awake()
    {
        _healthText = GetComponent<TMP_Text>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void LateUpdate()
    {
        _healthText.text = $"HP: {_player.CurrentHealth}";
    }
}
