using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement01 : MonoBehaviour
{

    public float speed = 6.0f;

    private Rigidbody2D rb;

    private Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        // Getting the Rigibody component so we can apply forces to it
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Creating a vector 2 to define which way we should move
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // The player's velocity is set to our direction * speed so we move in that direction, .normalize makes all movement equal (moving diagonally)
        moveVelocity = moveInput.normalized * speed;
    }

    private void FixedUpdate()
    {
        // Instead of putting movement code here, I created a move script to save space
        Move();
    }

    void Move()
    {
        // We grab the Rigidbody2D component and we move it towards our moveVelocity which contains our direction and speed
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
