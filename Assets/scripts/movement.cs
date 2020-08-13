using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class movement : MonoBehaviour
{
    public CharacterController2D controller;
    private Animator animator;
  


    float horizontalMove = 0f;
    public float runspeed = 50f;
    bool jump = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetAxisRaw("Horizontal") == 0)
        {
           animator.SetBool("Iswalking", false);
        }
        else
        {
           animator.SetBool("Iswalking", true);
        }
       
      horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            animator.SetTrigger("jump");
        }

    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove*Time.fixedDeltaTime, false, jump);
        jump = false;
    }
   
}
