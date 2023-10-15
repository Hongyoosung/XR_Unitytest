using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Enemy prefab
    public float spawnRate; // How often enemies are spawned, in seconds
    public Transform playerTransform; // Reference to the player's transform
    public float spawnerSize = 10f; // Size of the square spawner

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomPositionInSpawner();

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemy.GetComponent<Enemy>().SetTarget(playerTransform);
    }

    Vector3 GetRandomPositionInSpawner()
    {
        return new Vector3(
            Random.Range(transform.position.x - spawnerSize / 2, transform.position.x + spawnerSize / 2),
            transform.position.y,
            Random.Range(transform.position.z - spawnerSize / 2, transform.position.z + spawnerSize / 2)
        );
    }
}
