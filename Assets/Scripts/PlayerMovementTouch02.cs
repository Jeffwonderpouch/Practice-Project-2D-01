using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTouch02 : MonoBehaviour
{
    public float speed;
    public Joystick joystick;
    public float joystickDamnpen;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Vector2 moveInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(joystick.Horizontal >= joystickDamnpen || joystick.Horizontal <= -joystickDamnpen || joystick.Vertical <= joystickDamnpen || joystick.Vertical >= -joystickDamnpen)
        {
            // Values range from '-1' to '1'
            moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
            // We're going to be constantly adding this variable to the players position
            moveVelocity = moveInput * speed;
        }
        else
        {
            moveVelocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        // It is better to deal with physics in the FixedUpdate method because it is not frame rate dependent
        Move();
    }

    void Move()
    {
        // We are adding our position to the velocity, that is determined by coordinates from our joystick, multiplied by our speed and we are doing it in fixed intervals
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
