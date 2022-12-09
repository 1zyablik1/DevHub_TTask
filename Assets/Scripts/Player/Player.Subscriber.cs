using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    private void Subcribe()
    {
        Events.OnGlobalGameStateEnter += GlobalGameStateEnter;
        Events.OnGlobalFinishStateEnter += GlobalFinishStateEnter;

        Events.OnGameReset += GameReset;
    }

    private void Unsubscribe()
    {
        Events.OnGlobalGameStateEnter -= GlobalGameStateEnter;
        Events.OnGlobalFinishStateEnter -= GlobalFinishStateEnter;

        Events.OnGameReset -= GameReset;
    }

    private void GlobalFinishStateEnter()
    {
        SetZeroMove();
    }


    private void GlobalGameStateEnter()
    {
        SetRideMove();
    }

    private void GameReset()
    {
        this.transform.position = Vector3.zero;
        this.bikeTransfrom.rotation = Quaternion.Euler(Vector3.zero);

        stack.ResetStack();
    }
}
