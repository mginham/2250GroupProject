using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _myRigidbody;
    private Vector3 _change;
    private Animator _animator;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _change = Vector3.zero; // reset change to zero

        // Move based on keyboard input (no acceleration b/w still and motion to feel more digital)
        _change.x = Input.GetAxisRaw("Horizontal");
        _change.y = Input.GetAxisRaw("Vertical");

        // If there is motion in the keys, move the character, else remain idle
        UpdateAnimationAndMove();
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
        _myRigidbody.MovePosition(
            transform.position + _change * speed * Time.deltaTime
        );
    }
} // end class
