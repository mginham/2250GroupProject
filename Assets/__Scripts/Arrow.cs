using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public Rigidbody2D arrowRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Setup(Vector2 velocityOfArrow, Vector3 directionOfArrow)
    {
        arrowRigidBody.velocity = velocityOfArrow.normalized * speed;
        transform.rotation = Quaternion.Euler(directionOfArrow);
    }

}
