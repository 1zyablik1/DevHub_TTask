using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideMove : IMovableType
{
    private Transform playerTransform;
    private PlayerData playerData;
    private Transform bike;

    private Vector3 direction = new Vector3(0, 0, 1);
    private Vector3 joystickInput = Vector3.zero;

    public RideMove(Transform transform, PlayerData playerData, Transform bike)
    {
        this.playerTransform = transform;
        this.playerData = playerData;
        this.bike = bike;
    }

    public void Move()
    {
        GetJoystickInput();

        Ride();
        Rotate();
    }

    private void GetJoystickInput()
    {
        if (JoystickControl.Horizontal != 0 || JoystickControl.Vertical != 0)
        {
            joystickInput = new Vector3(JoystickControl.Horizontal * playerData.sideSpeed, 0, JoystickControl.Vertical * playerData.speedInputMultyply);
            
            return;
        }

        joystickInput = Vector3.zero;
    }

    private void Ride()
    {
        Vector3 moveDirection = ((direction * playerData.speed) + joystickInput) * Time.deltaTime;

        moveDirection = ClampX(playerTransform.position + moveDirection);

        playerTransform.position = moveDirection;
    }

    private void Rotate()
    {
        bike.rotation = Quaternion.Euler(0, 0, -15 * JoystickControl.Horizontal);
    }

    private Vector3 ClampX(Vector3 position)
    {
        return new Vector3(Mathf.Clamp(position.x, -1 * playerData.maxXoffset, playerData.maxXoffset), position.y, position.z);
    }
}
