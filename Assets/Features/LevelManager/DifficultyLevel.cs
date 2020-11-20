using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DifficultyLevel : MonoBehaviour
{
    public float timeBetweenWaves = 1.0f;
    public EnemyWave[] enemyWaves;
    private IEnumerator spawnCoroutine;

    public void StartSpawnRoutine()
    {
        spawnCoroutine = SpawnAndWait();
        StartCoroutine(spawnCoroutine);
    }

    public void StopSpawnRoutine()
    {
        StopCoroutine(spawnCoroutine);
    }

    IEnumerator SpawnAndWait()
    {
        while (true)
        {
            // Todo Get Random wave
            enemyWaves[0].SpawnEnemies();
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}