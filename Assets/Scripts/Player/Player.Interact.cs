using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player 
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.GetComponent<Entity>())
        {
            case Obstacle:
                Events.OnObstacleCollision?.Invoke();
                ObstacleCollision(collision);
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Trigger trigger;
        switch (trigger = other.gameObject.GetComponent<Trigger>())
        {

            case FinishTrigger:
                Events.OnFinishedLevel?.Invoke();
                break;
            case PizzaTrigger:
                PissaTriggered(trigger);
                break;
            default:
                break;
        }

    }

    private void ObstacleCollision(Collision collision)
    {
        if(!playerData.isDeadSideObstacle)
        {
            Vector3 direction = collision.GetContact(0).normal;

            if (direction.z == -1)
            {
                Lose();
            }
            return;
        }
        Lose();
    }

    private void PissaTriggered(Trigger trigger)
    {
        GetFromStack(((PizzaTrigger)trigger).GetEndPosition());
    }
}
