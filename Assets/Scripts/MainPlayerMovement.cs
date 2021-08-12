using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerMovement : MonoBehaviour
{
    [SerializeField] float horizontalSpeed;
    [SerializeField] float forwardSpeed;
    Vector3 lastPost;
    float direction;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPost = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            direction = GetDirection(Input.mousePosition.x, lastPost.x);
            lastPost = Vector3.Lerp(lastPost, Input.mousePosition, 0.2f);
            //transform.position = Vector3.Lerp(transform.position,  new Vector3(2 * direction, transform.position.y, transform.position.z), 0.1f);
            transform.Translate(((horizontalSpeed * new Vector3(direction, 0, 0)) + (Vector3.forward * forwardSpeed)) * Time.deltaTime);
            //rb.velocity = (horizontalSpeed * new Vector3(direction, 0, 0)) + (Vector3.forward );
        }
    }
    float GetDirection(float val1, float val2)
    {
        float direction = val1 - val2;
        if (direction > 0.2f && transform.position.x < 2)
        {
            return 1;
        }
        else if (direction < -0.2f && transform.position.x > -2)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}
