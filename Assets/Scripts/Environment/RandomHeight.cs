using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHeight : MonoBehaviour
{
    [SerializeField] float max, min;
    void Start()
    {
        foreach (Transform child in transform)
        {
            child.transform.position = new Vector3(child.position.x, Random.Range(min, max), child.position.z);
        }
    }
}
