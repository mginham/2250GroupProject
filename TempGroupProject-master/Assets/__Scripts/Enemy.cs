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
    public int health;
    public string enemyName; // "name" is a reserved word
    public int baseAttack;
    public float moveSpeed;
    public EnemyState currentState;

    public void Knock(Rigidbody2D myRigidbody, float knockTime)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
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
