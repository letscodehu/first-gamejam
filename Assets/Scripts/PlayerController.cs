using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float walkSpeed = 2;
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    private int currentHealth = 100;

    private int heading = 0;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private HealtBar healthbar;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        healthbar.SetMaxHealth(maxHealth);
        animator.SetFloat("VelocityY", -1);
    }

    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * walkSpeed, 0.8f),
                                             Mathf.Lerp(0, Input.GetAxis("Vertical") * walkSpeed, 0.8f));
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        if ((Math.Abs(x) + Math.Abs(y)) > .01f)
        {
            animator.SetFloat("VelocityX", x);
            animator.SetFloat("VelocityY", y);
            animator.SetBool("isMoving", true);
        }
        else {
            animator.SetBool("isMoving", false);
        }
    }
}
