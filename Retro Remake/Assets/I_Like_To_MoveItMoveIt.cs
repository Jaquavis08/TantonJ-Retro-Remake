using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class I_Like_To_MoveItMoveIt : MonoBehaviour
{
    public KeyCode left = KeyCode.A, right = KeyCode.D, up = KeyCode.W, down = KeyCode.S, jump = KeyCode.W;
    public float speed = 10;
    public Rigidbody2D rb;
    public Animator animator;

    public int health = 3;
    //Vector2 movement;

    private Vector2 targetVelocity;
    private Vector2 currentVelocity;
    private bool CanDamage = true;


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //// Input.GetKey() is for Holding a key
        //// Input.GetKeyDown() is for pressing a key
        //// InputKey.GetKeyUp() is for relesing a key

        //if (Input.GetKey(left))   // check for player holding down the left button
        //{
        //    // get the GameObject's Rigidbody2D component and set its velocity to be the left  at the given speed
        //    rb.velocity = Vector2.left * speed;
        //    Vector3 RotationLeft = new Vector3(0, 0, 90);
        //    transform.eulerAngles = RotationLeft;
        //}

        //if (Input.GetKey(right))    // check for player holding down the right button
        //{
        //    // get the GameObject's Rigidbody2D component and set its velocity to be the right  at the given speed
        //    rb.velocity = Vector2.right * speed;
        //    Vector3 RotationRight = new Vector3(0, 0, -90);
        //    transform.eulerAngles = RotationRight;
        //}

        //if (Input.GetKey(up))   // check for player holding down the up button
        //{
        //    // get the GameObject's Rigidbody2D component and set its velocity to be the up  at the given speed
        //    rb.velocity = Vector2.up * speed;
        //    Vector3 RotationUp = new Vector3(0, 0, 0);
        //    transform.eulerAngles = RotationUp;
        //}

        //if (Input.GetKey(down))  // check for player holding down the down button
        //{
        //    // get the GameObject's Rigidbody2D component and set its velocity to be the down  at the given speed
        //    rb.velocity = Vector2.down * speed;
        //    Vector3 RotationDown = new Vector3(0, 0, 180);
        //    transform.eulerAngles = RotationDown;
        //}

        //if (Input.GetKeyDown(jump))  // check for the player pressing the jump button
        //{
        //    // get the GameObject's Rigidbody2D component and set its velocity to be the jump  at the given speed
        //    rb.velocity = Vector2.up * jumpHeight;
        //}
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);

        MovePlayer();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(CanDamage)
            StartCoroutine(Damage());
        }
    }

    IEnumerator Damage()
    {
        CanDamage = false;
        health -= 1;
        yield return new WaitForSeconds(1f);
        CanDamage = true;
    }

    private void MovePlayer()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        Vector2 inputDirection = Vector2.zero;

        if (Input.GetKey(left)) inputDirection += Vector2.left;
        if (Input.GetKey(right)) inputDirection += Vector2.right;
        if (Input.GetKey(up)) inputDirection += Vector2.up;
        if (Input.GetKey(down)) inputDirection += Vector2.down;

        if (inputDirection != Vector2.zero)
        {
            inputDirection = inputDirection.normalized;
            targetVelocity = inputDirection * speed;

            float angle = Mathf.Atan2(inputDirection.y, inputDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }
        else
        {
            targetVelocity = Vector2.zero;
        }
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref currentVelocity, 0.1f);
    }
    void FixedUpdate()
    {
        
    }
    
}