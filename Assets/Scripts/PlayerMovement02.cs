using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement02 : MonoBehaviour
{

    public float speed = 4f;
    public float speedMultiplier = 2f;

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
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        if (Input.GetAxis("Sprint") != 0)
        {
            moveVelocity *= speedMultiplier;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
