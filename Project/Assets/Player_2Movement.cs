﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2Movement : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed = 40f;

    public Animator animator;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("HorizontalP2") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("JumpP2"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("CrouchP2"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("CrouchP2"))
        {
            crouch = false;
        }

    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    private void FixedUpdate()
    {
        // Move Our Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touched Coin");
        if (collision.gameObject.tag == "Coin")
        {
            GameObject coin = collision.gameObject;
            //coin.GetComponent<Renderer>().enabled = false;
            Destroy(coin);
            Debug.Log("Touched Coin Function");
            runSpeed = 100f;
        }
    }
}
