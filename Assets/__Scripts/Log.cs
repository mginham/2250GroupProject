using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy // inherit from Enemy class
{
    public Transform target;
    public Transform homePosition;
    public float chaseRadius;
    public float attackRadius;
    public Animator anim;
    private Rigidbody2D _myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;

        _myRigidbody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        // Find the location of the Player
        target = GameObject.FindWithTag("Player").transform;
    }

    // FixedUpdate goes on physics calls
    void FixedUpdate()
    {
        // Find distance from Log to target
        CheckDistance();
    }

    void CheckDistance()
    {
        // If target is within chaseRadius, move towards the target (don't move closer than attackRadius)
        if((Vector3.Distance(target.position, transform.position) <= chaseRadius) && (Vector3.Distance(target.position, transform.position) > attackRadius))
        {
            // Only move if in idle or walk state (don't want Log to move if in stagger state)
            if ((currentState == EnemyState.idle || currentState == EnemyState.walk) && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

                ChangeAnim(temp - transform.position);
                _myRigidbody.MovePosition(temp);

                ChangeState(EnemyState.walk);

                anim.SetBool("wakeUp", true);
            }
        }
        else if(Vector3.Distance(target.position, transform.position) > chaseRadius) // Don't want Log to fall asleep in chaseRadius
        {
            anim.SetBool("wakeUp", false);
        }
    }

    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    private void ChangeAnim(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Determine if left or right (if zero, do nothing)
            if(direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if(direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            // Determine if up or down (if zero, do nothing)
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    private void ChangeState(EnemyState newState)
    {
        // If newState is different than currentState, change currentState to match newState
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}
