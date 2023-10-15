using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{
    public AudioClip spawnSound; // The sound to play when an enemy is spawned
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public float spawnInterval = 1f; // The interval between each spawn
    public Vector3 spawnArea = new Vector3(10, 0, 10); // The area within which enemies are spawned

    private float timer;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();

            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        GameObject player = GameObject.FindGameObjectWithTag("player"); // Assuming the player object has the tag "Player"
        Vector3 spawnPosition;

        if (player != null)
        {
            do
            {
                // Calculate a random position within the spawn area but always start at y=-5
                spawnPosition = new Vector3(
                    Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                    -5,
                    Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
                );
            }
            while (Vector3.Distance(player.transform.position, transform.position + spawnPosition) < 5f);
        }
        else
        {
            Debug.LogError("No Player object found. Please make sure your player is tagged with 'Player'.");
            return;
        }

        // Create a new enemy at the calculated position
        Instantiate(enemyPrefab, transform.position + spawnPosition, Quaternion.identity);

        if (audioSource != null && spawnSound != null)
        {
            audioSource.PlayOneShot(spawnSound);
        }
    }

}
