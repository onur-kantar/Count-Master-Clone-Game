using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerMovement : Movement
{
    [SerializeField] float tempHorizontalSpeed;
    [SerializeField] float tempVerticleSpeed;
    float horizontalSpeed;
    float verticleSpeed;
    Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public override void Move(Vector3 direction)
    {
        rb.velocity = new Vector3(direction.x * horizontalSpeed, 0, verticleSpeed);
    }
    public override void StopMovement()
    {
        horizontalSpeed = 0;
        verticleSpeed = 0;
        rb.velocity = Vector3.zero;
    }
    public override void StartMovement()
    {
        horizontalSpeed = tempHorizontalSpeed;
        verticleSpeed = tempVerticleSpeed;
    }
}
