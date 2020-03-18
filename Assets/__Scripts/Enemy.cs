using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// States of the Enemy
public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    public float health;
    public FloatValue maxHealth;
    public string enemyName; // "name" is a reserved word
    public int baseAttack;
    public float moveSpeed;
    public EnemyState currentState;

    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    private void TakeDamage(float damage)
    {
        // Decriment health by damage
        health -= damage;

        // If health is equal to or falls below zero, remove the object
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        // Check if enemy is still present (hasn't died after hit)
        if (myRigidbody != null)
        {
            // Allow some time so that the knockback can take place
            yield return new WaitForSeconds(knockTime);
            
            // Set velocity to zero so that it stops moving after being knocked back
            myRigidbody.velocity = Vector2.zero;
            
            //Reset state
            currentState = EnemyState.idle;

            // Set velocity to zero so that it stops moving after state change
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
