using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovement: MonoBehaviour
{
    void FixedUpdate()
    {
        //rb.MovePosition(transform.position + (transform.parent.position - transform.position) * Time.fixedDeltaTime);
        transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, 0.02f);
    }
}
