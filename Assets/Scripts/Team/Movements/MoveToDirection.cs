using UnityEngine;

public abstract class MoveToDirection : MonoBehaviour
{
    Movement movement;
    private void Awake()
    {
        movement = GetComponent<Movement>();
    }
    void Update()
    {
        movement.Move(CalculateDirection());
    }
    public abstract Vector3 CalculateDirection();
}