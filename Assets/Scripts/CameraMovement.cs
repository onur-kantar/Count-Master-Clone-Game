using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 offset;
    private void Start()
    {
        offset = transform.position - target.position;
    }
    void Update()
    {
        float x = Mathf.Lerp(transform.position.x, (target.position.x + offset.x), 0.05f);
        transform.position = new Vector3(x, target.position.y + offset.y, target.position.z + offset.z);
    }
}
