using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;

public class playerMovements : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction inputAction;
    private float inputDirection;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public static Animator anim;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        inputAction = playerInput.actions.FindAction("Movement");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GiveDamage.moveBan)
        {
            jumpControl();
        }
        speedBosstControl();
    }
    private void FixedUpdate()
    {
        if (!GiveDamage.moveBan)
        {
            movement();
        }
    }
    void jumpControl()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && collisionControl.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
    void movement()
    {
        Vector2 direction = inputAction.ReadValue<Vector2>();
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
        if (direction.x < 0)
        {
            sr.flipX = true;
            anim.SetBool("isRunning", true);
        }
        else if (direction.x > 0)
        {
            sr.flipX = false;
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
    public void finishOfDamageAnimation()
    {
        GetComponent<Animator>().ResetTrigger("hitted");
    }
    void speedBosstControl()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 4;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 2;
        }
    }
}
