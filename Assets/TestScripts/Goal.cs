using UnityEngine;

public class Goal : MonoBehaviour
{
    public int scoreIncrease = 1; // How much the player's score increases when an enemy is destroyed

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Increase the player's score
            PlayerScore.score += scoreIncrease;

            // Destroy the enemy object
            Destroy(collision.gameObject);
        }
    }
}
