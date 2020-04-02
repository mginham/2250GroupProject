using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBoss : Enemy
{

    public Animator anim;
    private Rigidbody2D _myRigidBody;
    public GameObject wizardBossFireball; //fireball object that boss throws
    public GameObject arrowProjectile;
    private float timestamp = 0.0f;//recording time between big fireballs
    private float timeStamp2 = 0.0f;//recording time between small fireballs
    private float timeBetweenProjectiles = 5f;//Frequency of the larger more damaging fireball coming from the boss
    private float timeBetweenSmallFireball = 1f;//Frequency of small fireballs coming from the boss
    public Transform target;
    public float min; 
    public float max;
    public float attackRadius;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        _myRigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        min = _myRigidBody.position.x-10;
        max = (_myRigidBody.position.x)+10;
    }

    bool inrange;
    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }
    void CheckDistance()
    {
        if ((Vector3.Distance(target.position, transform.position) <= attackRadius) || inrange == true)
        {
            inrange = true;
            moveBoss();

        }
    }
    //Controls the movement of the wizard boss
    void moveBoss()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time * 2, max - min) + min,transform.position.y);

        //Creating small fireball projectiles
        if (Time.time > timeStamp2)
        {
            StartCoroutine(AttackArrowCo());
            timeStamp2 = Time.time + timeBetweenSmallFireball;
        }
        
        //Creating large fireball
        if (Time.time > timestamp)
        {
            StartCoroutine(AttackFireBallCo());
            timestamp = Time.time + timeBetweenProjectiles;//Update when the next projectile is coming
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

    private void MakeFireBall()
    {
        Vector2 moveTemp = new Vector2(anim.GetFloat("moveX"), 1);
        Arrow arrow = Instantiate(wizardBossFireball, transform.position, Quaternion.identity).GetComponent<Arrow>();
        arrow.Setup(moveTemp, ChooseArrowDirection());
    }

    Vector3 ChooseArrowDirection()
    {
        float temp = Mathf.Atan2(anim.GetFloat("moveY"), anim.GetFloat("moveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }

    private IEnumerator AttackFireBallCo()
    {
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(1.3f);
        MakeFireBall();
        anim.SetBool("isAttack", false);

    }

    private void MakeArrow()
    {
        /*Vector2 moveTemp = new Vector2(1.5f,0.5f);
        Arrow arrow = Instantiate(arrowProjectile, transform.position, Quaternion.identity).GetComponent<Arrow>();
        arrow.Setup(moveTemp, ChooseArrowDirection());*/

        Vector2 moveTemp2 = new Vector2(0f,1f);
        Arrow arrow2 = Instantiate(arrowProjectile, transform.position,Quaternion.identity).GetComponent<Arrow>();
        arrow2.Setup(moveTemp2, ChooseArrowDirection());
    }


    private IEnumerator AttackArrowCo()
    {
        yield return new WaitForSeconds(1f);
        MakeArrow();
        yield return new WaitForSeconds(1f);

    }
}
