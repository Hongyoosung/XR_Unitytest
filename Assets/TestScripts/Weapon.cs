using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float knockbackForce = 10f; // The force with which enemies are knocked back

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object we collided with is an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (enemyRigidbody != null)
            {
                // Calculate the direction from the player to the enemy
                Vector3 knockbackDirection = collision.transform.position - transform.position;
                knockbackDirection.Normalize();

                // Apply a force to the enemy in the opposite direction of the player (knockback)
                enemyRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);

                // Enable gravity on the enemy's Rigidbody
                enemyRigidbody.useGravity = true;
            }
        }
    }
}
