using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// States of the Player
public enum PlayerState //TODO: add different states for different types of attack, dying, dash
{
    walk,
    swordAttack,
    interact,
    idle,
    stagger
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D _myRigidbody;
    private Vector3 _change;
    private Animator _animator;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;


    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        _animator = GetComponent<Animator>();
        _myRigidbody = GetComponent<Rigidbody2D>();

        // Set initial values to be downward facing, so that idle attacks without initial movement will activate down attack instead of activating all attacks
        _animator.SetFloat("moveX", 0);
        _animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        // reset change to zero
        _change = Vector3.zero;

        // Move based on keyboard input (no acceleration between still and motion to feel more digital)
        _change.x = Input.GetAxisRaw("Horizontal");
        _change.y = Input.GetAxisRaw("Vertical");

        // If there is motion in the keys, move the character, else remain idle
        if (Input.GetButtonDown("swordAttack") && currentState != PlayerState.swordAttack && currentState != PlayerState.stagger) // Activate swordAttacking animation if not already in that state
        {
            StartCoroutine(AttackCo());
        }
        else if(currentState == PlayerState.walk || currentState == PlayerState.idle) // Activate walking animation
        {
            UpdateAnimationAndMove();
        }
    }

    // Coroutine runs in parallel to main process (build in specific delays)
    private IEnumerator AttackCo()
    {
        // Activate swordAttacking animation
        _animator.SetBool("swordAttacking", true);
        currentState = PlayerState.swordAttack;
        yield return null; // Wait 1 frame

        // Disable swordAttacking animation after animation ends and return to walking animation
        _animator.SetBool("swordAttacking", false);
        yield return new WaitForSeconds(.3f); // Wait 0.3 seconds (length of attack animation)
        currentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove()
    {
        // If there is movement, cause the character sprite to move, else make the sprite idle
        if (_change != Vector3.zero)
        {
            MoveCharacter();
            _animator.SetFloat("moveX", _change.x);
            _animator.SetFloat("moveY", _change.y);
            _animator.SetBool("moving", true);
        }
        else
        {
            _animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        // Grab position of the player and move a small amount each frame
        _change.Normalize(); // Stop diagonal walking from being faster than axis walking
        _myRigidbody.MovePosition(
            transform.position + _change * speed * Time.deltaTime);
    }

    public void Knock(float knockTime, float damage)
    {
        currentHealth.runtimeValue -= damage;
        playerHealthSignal.Raise();

        // Check if Player is still alive
        if (currentHealth.runtimeValue > 0)
        {
            StartCoroutine(KnockCo(knockTime));
        }
        else
        {
            // Player death
            this.gameObject.SetActive(false);
        }
        
    }

    private IEnumerator KnockCo(float knockTime)
    {
        // Check if enemy is still present (hasn't died after hit)
        if (_myRigidbody != null)
        {
            // Allow some time so that the knockback can take place
            yield return new WaitForSeconds(knockTime);

            // Set velocity to zero so that it stops moving after being knocked back
            _myRigidbody.velocity = Vector2.zero;

            //Reset state
            currentState = PlayerState.idle;

            // Set velocity to zero so that it stops moving after state change
            _myRigidbody.velocity = Vector2.zero;
        }
    }
} // end class
