using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float minRotationSpeed = 100f; // Minimum rotation speed
    public float maxRotationSpeed = 300f; // Maximum rotation speed

    private float rotationSpeed;
    private Transform targetTransform;

    void Start()
    {
        // Set a random rotation speed within the defined range
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    public void SetTarget(Transform target)
    {
        this.targetTransform = target;
    }

    void Update()
    {
        if (targetTransform != null)
        {
            Vector3 directionToTarget = (targetTransform.position - transform.position).normalized;
            transform.Translate(directionToTarget * speed * Time.deltaTime, Space.World);

            // Rotate the enemy towards the player
            Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

            // Make the enemy rotate around its own axis
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Plane"))
        {
            Destroy(gameObject);
        }

    }
}
