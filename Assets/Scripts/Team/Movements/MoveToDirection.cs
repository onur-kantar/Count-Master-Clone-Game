using UnityEngine;

public abstract class MoveToDirection : MonoBehaviour
{
    Vector3 direction;
    Movement movement;
    private void Awake()
    {
        movement = GetComponent<Movement>();
    }
    private void Update()
    {
        direction = CalculateDirection();
    }
    void FixedUpdate()
    {
        movement.Move(direction);
    }
    public abstract Vector3 CalculateDirection();
}