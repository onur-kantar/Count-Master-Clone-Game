using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [HideInInspector] public Vector3 lookAtDeflection;
    Vector3 offset;
    Transform cam;
    Animation anim;
    bool look;
    private void Start()
    {
        cam = transform.GetChild(0);
        anim = GetComponent<Animation>();
        offset = transform.position - target.position;
        lookAtDeflection = Vector3.up;
    }
    void Update()
    {
        transform.position = target.position + offset;
        if (look)
        {
            cam.rotation = Quaternion.RotateTowards(cam.rotation, Quaternion.LookRotation(target.position - cam.position + lookAtDeflection), Time.deltaTime * 5);
        }
    }
    public void EndGameAnim(Transform target)
    {
        anim.Play("CameraEndGame");
        this.target = target;
        offset = transform.position - target.position;
        look = true;
        lookAtDeflection = Vector3.zero;
    }
}
