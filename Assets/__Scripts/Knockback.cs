using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If breakable, activate smash animation
        if (other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Pot>().Smash();
        }

        // If enemy or Player, activate knockback animation
        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hittable = other.GetComponent<Rigidbody2D>();

            // Check if rigidbody is present
            if(hittable != null)
            {
                // Apply force
                Vector2 difference = hittable.transform.position - transform.position;
                difference = difference.normalized * thrust; // Normalized ensures vector is of length one
                hittable.AddForce(difference, ForceMode2D.Impulse);

                // If object is enemy, activate stagger state
                if (other.gameObject.CompareTag("enemy"))
                {
                    hittable.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hittable, knockTime);
                }

                // If object is Player, activate stagger state
                if (other.gameObject.CompareTag("Player"))
                {
                    hittable.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                    other.GetComponent<PlayerMovement>().Knock(knockTime);
                }
            }
        }
    }
}
