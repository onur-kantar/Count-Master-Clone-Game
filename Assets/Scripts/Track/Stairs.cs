using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform;
        other.GetComponent<TeamMember>().leader.IncreaseFinishedHumanCount();
    }
}
