using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public CharacterController2D controller;
    private float Move = 0f;
    private float direction = 1f;
    public float runspeed ;
    public Transform hoverpoint;
    public float hoverdistance = 5f;

    private void Start()
    {


    }
    private void Update()
    {
        float distance = transform.position.x - hoverpoint.transform.position.x;
      //  Debug.Log(distance);
        if(distance > hoverdistance)
        {
            direction = -1;
        }
        if(distance < -hoverdistance)
        {
            direction =  1;
        }
            Move = direction * runspeed;
        
    }
    private void FixedUpdate()
    {
        controller.Move(Move * Time.fixedDeltaTime, false, false);
    }
}
