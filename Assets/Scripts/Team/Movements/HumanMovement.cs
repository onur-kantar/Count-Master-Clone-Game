using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovement : Movement
{
    [SerializeField] float speed;

    public override void Move(Vector3 direction)
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, direction, speed * Time.fixedDeltaTime);
    }
}
