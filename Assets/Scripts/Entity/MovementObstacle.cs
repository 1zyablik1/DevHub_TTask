using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObstacle : Obstacle
{
    private float speed = 2.5f;
    private bool isMove = false;


    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        Events.OnGlobalGameStateEnter += GlobalGameStateEnter;
        Events.OnGlobalGameStateExit += GlobalGameStateExit;
    }

    private void Unsubscribe()
    {
        Events.OnGlobalGameStateEnter -= GlobalGameStateEnter;
        Events.OnGlobalGameStateExit -= GlobalGameStateExit;
    }

    private void GlobalGameStateEnter()
    {
        isMove = true;
    }
    
    private void GlobalGameStateExit()
    {
        isMove = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Trigger trigger;
        switch (trigger = collision.gameObject.GetComponent<Trigger>())
        {

            case BusStopTrigger:
                ResetPosition(trigger);

                break;
        }

    }

    private void FixedUpdate()
    {
        if(isMove)
        {
            Move();
        }
    }

    private void Move()
    {
        this.transform.position += this.gameObject.transform.forward * speed * Time.deltaTime;
    }

    private void ResetPosition(Trigger trigger)
    {
        this.transform.position = ((BusStopTrigger)trigger).GetStartPoint();
    }
}
