using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanCreator : MonoBehaviour
{
    enum Operation { Sum, Multiplication };
    [SerializeField] GameObject human;
    [SerializeField] Operation operation;
    [SerializeField] float value;
    float count;
    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;
        if (operation == Operation.Sum)
        {
            count = value;
        }
        else if (operation == Operation.Multiplication)
        {
            count = parent.childCount * value;
        }
        for (int i = 0; i < count; i++)
        {
            Vector3 position = new Vector3(Random.Range(parent.position.x - 0.5f, parent.position.x + 0.5f),
                                           parent.position.y,
                                           Random.Range(parent.position.z - 0.5f, parent.position.z + 0.5f));
            GameObject go = Instantiate(human, position, Quaternion.identity);
            go.transform.parent = parent;
        }
        Destroy(gameObject);
    }
}
