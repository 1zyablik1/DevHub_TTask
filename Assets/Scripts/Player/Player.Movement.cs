using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player 
{
    private IMovableType currentMoveType;
    private IMovableType zeroMoveType;
    private IMovableType rideMoveType;

    [SerializeField] private Transform bikeTransfrom;
    private static Transform staticTransfrom;

    private void MovementStart()
    {
        zeroMoveType = new ZeroMove();
        rideMoveType = new RideMove(this.transform, playerData, bikeTransfrom);

        staticTransfrom = this.transform;

        SetZeroMove();
    }

    private void SetZeroMove()
    {
        currentMoveType = zeroMoveType;
    }

    private void SetRideMove()
    {
        currentMoveType = rideMoveType;
    }

    private void MovementFixedUpdate()
    {
        currentMoveType.Move();
    }

    public static float GetZPosition()
    {
        return staticTransfrom.position.z;
    }
}
