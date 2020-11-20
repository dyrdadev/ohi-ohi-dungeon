using System.Collections;
using UnityEngine;

public class DifficultyLevel : MonoBehaviour
{
    public EnemyWave[] enemyWaves;
    private IEnumerator spawnCoroutine;
    public float timeBetweenWaves = 1.0f;

    public void StartSpawnRoutine()
    {
        spawnCoroutine = SpawnAndWait();
        StartCoroutine(spawnCoroutine);
    }

    public void StopSpawnRoutine()
    {
        StopCoroutine(spawnCoroutine);
    }

    private IEnumerator SpawnAndWait()
    {
        while (true)
        {
            // Todo Get Random wave
            enemyWaves[0].SpawnEnemies();
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}