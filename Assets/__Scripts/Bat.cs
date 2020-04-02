using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{

    public Transform target;
    public Transform homePosition;
    public float chaseRadius;
    public float attackRadius;
    public Animator anim;
    private Rigidbody2D _myRigidBody;
    public GameObject fireProjectile;
    private float timestamp = 0.0f;
    private float timeBetweenProjectiles = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;

        _myRigidBody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        //Find the location of the Player;
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Find the distance from the bat to the target
        CheckDistance();

    }

    void CheckDistance()
    {
        // If target is within chaseRadius, move towards the target (don't move closer than attackRadius)
        if ((Vector3.Distance(target.position, transform.position) <= chaseRadius) && (Vector3.Distance(target.position, transform.position) > attackRadius))
        {
            // Only move if in idle or walk state (don't want Log to move if in stagger state)
            if ((currentState == EnemyState.idle || currentState == EnemyState.walk) && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

                ChangeAnim(temp - transform.position);
                _myRigidBody.MovePosition(temp);

                ChangeState(EnemyState.walk);

                anim.SetBool("wakeUp", true);
            }

            //Periodically the bat will shoot projectiles at the player
            if (Time.time > timestamp)
            {
                StartCoroutine(AttackArrowCo());
                timestamp = Time.time + timeBetweenProjectiles;
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius) // Don't fall asleep in chaseRadius
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
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Determine if left or right (if zero, do nothing)
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
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
        if (currentState != newState)
        {
            currentState = newState;
        }
    }

    private void MakeArrow()
    {
        //Vector3 spawnInfront = new Vector3 (transform.position.x + transform.position.x*0.2f, transform.position.y + transform.position.y*0.2f);
        Vector2 moveTemp = new Vector2(anim.GetFloat("moveX"), anim.GetFloat("moveY"));
        Arrow arrow = Instantiate(fireProjectile, transform.position, Quaternion.identity).GetComponent<Arrow>();
        arrow.Setup(moveTemp, ChooseArrowDirection());
    }

    Vector3 ChooseArrowDirection()
    {
        float temp = Mathf.Atan2(anim.GetFloat("moveY"), anim.GetFloat("moveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }

    private IEnumerator AttackArrowCo()
    {

        MakeArrow();
        yield return null;

    }

}
