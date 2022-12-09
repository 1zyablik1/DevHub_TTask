using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusStopTrigger : Trigger
{
    [SerializeField] 
    private Transform startPoint;

    public Vector3 GetStartPoint()
    {
        return startPoint.position;
    }    
}
