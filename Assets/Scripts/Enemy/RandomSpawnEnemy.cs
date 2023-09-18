using UnityEngine;
using System.Collections;

public class RandomSpawnEnemy : MonoBehaviour
{
    [SerializeField] private float _startTimeBtwSpawns;
    [SerializeField] private GameObject[] _enemies;
    private GameObject[] _spawnPoints;
    private SpawnPoint _spawnPointScript;
    private Transform _enemyContainer;
    private int _rand;
    private int _randPosition;
    private float _timeBtwSpawns;
    private void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        _spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        _enemyContainer = GameObject.FindGameObjectWithTag("EnemyContainer").transform;
        _timeBtwSpawns = _startTimeBtwSpawns;
    }

    private void LateUpdate()
    {
        if(_timeBtwSpawns <= 0)
        {
            _randPosition = Random.Range(0, _spawnPoints.Length);
            _spawnPointScript = _spawnPoints[_randPosition].GetComponent<SpawnPoint>();
            if (!_spawnPointScript.IsHaveEnemy)
            {
                _spawnPointScript.SetHaveEnemy(true);
                _rand = Random.Range(0, _enemies.Length);
                Instantiate(_enemies[_rand], _spawnPoints[_randPosition].transform.position, Quaternion.identity, _enemyContainer);
                StartCoroutine(_spawnPointScript.ISetHaveEnemyBtwTime(_enemies[_rand].GetComponentInChildren<Stats>().MaxLifeTime));
                _timeBtwSpawns = _startTimeBtwSpawns;
            }
        }
        else
        {
            _timeBtwSpawns -= Time.deltaTime;
        }
    }
}
