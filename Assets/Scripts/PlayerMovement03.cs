﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement03 : MonoBehaviour
{
    public float speed;

    public Joystick joystick;
    public float joystickDampen;

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
        if(joystick.Horizontal >= joystickDampen || joystick.Vertical >= joystickDampen || joystick.Horizontal <= -joystickDampen || joystick.Vertical <= -joystickDampen)
        {
            moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
            moveVelocity = moveInput * speed;
        }
        else
        {
            moveVelocity = new Vector2(0,0);
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
