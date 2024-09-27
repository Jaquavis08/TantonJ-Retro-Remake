using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class I_Like_To_MoveItMoveIt : MonoBehaviour
{
    public KeyCode left = KeyCode.A, right = KeyCode.D, up = KeyCode.W, down = KeyCode.S, jump = KeyCode.W;
    public float speed = 10, jumpHeight = 15;
    public Animator animator;
    Vector2 movement;

    public Rigidbody2D _rb;

    // Start is called before the first frame update

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetKey() is for Holding a key
        // Input.GetKeyDown() is for pressing a key
        // InputKey.GetKeyUp() is for relesing a key

        if (Input.GetKey(left))   // check for player holding down the left button
        {
            // get the GameObject's Rigidbody2D component and set its velocity to be the left  at the given speed
            _rb.velocity = Vector2.left * speed;
        }

        if (Input.GetKey(right))    // check for player holding down the right button
        {
            // get the GameObject's Rigidbody2D component and set its velocity to be the right  at the given speed
            _rb.velocity = Vector2.right * speed;
        }

        if (Input.GetKey(up))   // check for player holding down the up button
        {
            // get the GameObject's Rigidbody2D component and set its velocity to be the up  at the given speed
            _rb.velocity = Vector2.up * speed;
        }

        if (Input.GetKey(down))  // check for player holding down the down button
        {
            // get the GameObject's Rigidbody2D component and set its velocity to be the down  at the given speed
            _rb.velocity = Vector2.down * speed;
        }

        if (Input.GetKeyDown (jump))  // check for the player pressing the jump button
        {
            // get the GameObject's Rigidbody2D component and set its velocity to be the jump  at the given speed
            _rb.velocity = Vector2.up * jumpHeight;
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}