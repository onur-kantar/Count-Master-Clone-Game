using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;
        parent.GetComponent<BuildTower>().Build();
        GetComponent<Collider>().enabled = false;
    }
}
