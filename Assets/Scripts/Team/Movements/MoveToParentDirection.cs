using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToParentDirection : MoveToDirection
{
    public override Vector3 CalculateDirection()
    {
        return Vector3.zero;
    }
}
