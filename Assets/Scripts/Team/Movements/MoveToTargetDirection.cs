using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetDirection : MoveToDirection
{
    [HideInInspector] public Vector3 target;
    public override Vector3 CalculateDirection()
    {
        return target;
    }
}
