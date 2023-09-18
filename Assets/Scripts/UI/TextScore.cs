using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScore : MonoBehaviour
{
    private TMP_Text _scoreText;
    private GameController _gameController;

    private void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void LateUpdate()
    {
        _scoreText.text = $"Score: {_gameController.Score}";
    }
}
