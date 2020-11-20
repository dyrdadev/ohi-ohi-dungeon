using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    private List<EnemySpawn> _enemySpawns = new List<EnemySpawn>();

    public void RegisterEnemySpawn(EnemySpawn enemySpawn)
    {
        _enemySpawns.Add(enemySpawn);
    }

    public void SpawnEnemies()
    {
        foreach (var enemySpawn in _enemySpawns)
        {
            enemySpawn.SpawnEnemy();
        }
    }
}
