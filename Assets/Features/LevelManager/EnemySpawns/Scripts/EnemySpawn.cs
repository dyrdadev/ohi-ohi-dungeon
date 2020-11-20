using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;

    private void Awake()
    {
        GetComponentInParent<EnemyWave>().RegisterEnemySpawn(this);
    }

    public void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}