using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaTrigger : Trigger
{
    [SerializeField] private Transform endPosition;
    public Transform GetEndPosition()
    {
        return endPosition;
    }
}
