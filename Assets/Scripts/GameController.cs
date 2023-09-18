using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float Score;
    private float _score;
    [SerializeField] private GameObject[] _gridPrefabs;
    [SerializeField] private GameObject _playerHealthBar;
    [SerializeField] private GameObject _textToWin;
    [SerializeField] private GameObject _textToLose;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private int _pointToWin;
    [SerializeField] private GameObject _timer;
    private RandomSpawnEnemy _spawnEnemy;
    private Player _player;
    private Transform _gridContainer;
    private Vector3 _spawnGridPosition;
    private bool _stopGetScore;

    private void Awake()
    {
        _gridContainer = GameObject.Find("Environmental").transform;
        _spawnGridPosition = GameObject.Find("Environmental").transform.position;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _textToLose.SetActive(false);
        _textToWin.SetActive(false);
        _playerHealthBar.SetActive(false);
        _score = 0; 
        Score = 0;
        _stopGetScore = false;
    }
    private void LateUpdate()
    {
        if(_score >= _pointToWin)
        {
            _pauseMenu.Pause();
            _textToWin.SetActive(true);
            _stopGetScore = true;
        }
        if (_player.CurrentHealth <= 0)
        {
            _pauseMenu.Pause();
            _textToLose.SetActive(true);
            _stopGetScore = true;
        }
    }
    public void IncreaseScore(float amount)
    {
        if (!_stopGetScore)
        {
            if (amount < 0)
            {
                Debug.LogError("Trying to arrive at score a negative number!");
            }

            _score += amount;
            Score = _score;
        }
    }
    public void CreateWorld(int amountGrid, int amountPlayMode)
    {
        Destroy(GameObject.FindGameObjectWithTag("Grid"));
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++) { Destroy(enemies[i]); }

        _score = 0;
        Score = _score;
        _player.SetPlayerHealthToMax();
        _textToWin.SetActive(false);
        _textToLose.SetActive(false);
        switch (amountPlayMode)
        {
            case 0: 
                _playerHealthBar.SetActive(true);
                _player.SetPlayerGodMode(false);
                _timer.SetActive(false);
                _timer.GetComponent<Timer>().OnTimerZero -= TimerZero;
                _stopGetScore = false;
                break;
            case 1:
                _playerHealthBar.SetActive(false);
                _player.SetPlayerGodMode(true);
                _timer.SetActive(true);
                _timer.GetComponent<Timer>().OnTimerZero += TimerZero;
                _timer.GetComponent<Timer>().StartTimer();
                _stopGetScore = false;
                break;
        }
            

        Instantiate(_gridPrefabs[amountGrid], _spawnGridPosition, Quaternion.identity, _gridContainer);
        _spawnEnemy = GameObject.FindGameObjectWithTag("Grid").GetComponent<RandomSpawnEnemy>();
        _spawnEnemy.StartGame();
    }
    private void TimerZero()
    {
        if(_score < _pointToWin)
        {
            _pauseMenu.Pause();
            _textToLose.SetActive(true);
        }
        _stopGetScore = true;
    }
}
