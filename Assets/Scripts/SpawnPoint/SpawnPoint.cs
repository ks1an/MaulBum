using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour
{
    public bool IsHaveEnemy { get; private set; }

    private void Awake()
    {
        IsHaveEnemy = false;
    }

    public void SetHaveEnemy(bool isHaveEnemy)
    {
        IsHaveEnemy = isHaveEnemy;
    }


    public IEnumerator ISetHaveEnemyBtwTime(float enemyLifeTime)
    {
        yield return new WaitForSeconds(enemyLifeTime);
        SetHaveEnemy(false);
    }
}
