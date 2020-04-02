using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    public float damage;

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
                if (other.gameObject.CompareTag("enemy") || (other.gameObject.CompareTag("Player") && !this.gameObject.CompareTag("projectile")))
                {
                    Vector2 difference = hittable.transform.position - transform.position;
                    difference = difference.normalized * thrust; // Normalized ensures vector is of length one
                    hittable.AddForce(difference, ForceMode2D.Impulse);
                }

                // If object is enemy, activate stagger state
                if (other.gameObject.CompareTag("enemy") && !this.gameObject.CompareTag("enemyProjectile"))
                {
                    hittable.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hittable, knockTime, damage);
                }

                // If object is Player, activate stagger state
                if (other.gameObject.CompareTag("Player") && !this.gameObject.CompareTag("projectile"))
                {
                    // Check to make sure Player is not already in stagger state
                    if(other.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
                    {
                        hittable.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                        other.GetComponent<PlayerMovement>().Knock(knockTime, damage);
                    }
                    
                }
            }
        }
    }
}
