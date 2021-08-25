using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToSwipeDirection : MoveToDirection
{
    [SerializeField] float swiperStopTolerance;
    [SerializeField] float endPointSpeed;
    Vector3 startPoint;
    Vector3 endPoint;
    float inputSpeed;
    Camera cam;

    void Start()
    {
        endPoint = Vector3.zero;
        cam = Camera.main;
    }
    public override Vector3 CalculateDirection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
            endPoint = startPoint;
        }
        if (Input.GetMouseButton(0))
        {
            startPoint = cam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
            inputSpeed = GetSwipeSpeed(startPoint.x, endPoint.x);
            endPoint = Vector3.Lerp(endPoint, startPoint, endPointSpeed * Time.deltaTime);
            return new Vector3(inputSpeed, 0, 0);
        }
        return Vector3.zero;
    }
    float GetSwipeSpeed(float startPoint, float endPoint)
    {
        float inputSpeed = startPoint - endPoint;
        if (Mathf.Abs(inputSpeed) > swiperStopTolerance)
        {
            return inputSpeed;
        }
        else
        {
            return 0;
        }
    }
}
