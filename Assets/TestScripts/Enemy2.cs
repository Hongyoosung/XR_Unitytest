using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour
{
    public AudioClip deathSound;
    private AudioSource audioSource;

    public int scoreValue = 1; // How much the player's score increases when this enemy is destroyed
    public float emergeTime = 0.5f; // The time it takes for the enemy to emerge from the ground

    private Vector3 startPosition;
    private Vector3 endPosition;
    private Rigidbody enemyRigidbody;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Set the start and end positions
        startPosition = transform.position;
        endPosition = new Vector3(transform.position.x, 0, transform.position.z);

        // Start the emergence routine
        StartCoroutine(EmergeFromGround());

        // Get the Rigidbody component and initially disable it
        enemyRigidbody = GetComponent<Rigidbody>();

        if (enemyRigidbody != null)
        {
            enemyRigidbody.useGravity = false;
            //enemyRigidbody.isKinematic = true;
        }
            
        else
            Debug.LogError("No Rigidbody found on Enemy prefab.");
    }

    IEnumerator EmergeFromGround()
    {
        float t = 0;

        while (t < emergeTime)
        {
            // Interpolate between the start and end positions based on t/emergeTime
            transform.position = Vector3.Lerp(startPosition, endPosition, t / emergeTime);

            t += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object we collided with is the player's weapon
        if (collision.gameObject.CompareTag("Weapon"))
        {
            // Increase the player's score
            PlayerScore.score += scoreValue;

            if (enemyRigidbody != null)
            {
                enemyRigidbody.useGravity = true;
                //enemyRigidbody.isKinematic = false;
            }

            if (audioSource != null && deathSound != null)
            {
                audioSource.PlayOneShot(deathSound);
            }

            // wait 3 seconds
            StartCoroutine(WaitAndDestroy(1f));
        }
    }

    IEnumerator WaitAndDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
