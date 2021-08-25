using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovement : Movement
{
    [SerializeField] float tempSpeed;
    float speed;
    public override void Move(Vector3 direction)
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, direction, speed * Time.fixedDeltaTime);
    }
    public override void StopMovement()
    {
        speed = 0;
    }
    public override void StartMovement()
    {
        speed = tempSpeed;
    }
}
