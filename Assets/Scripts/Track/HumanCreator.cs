using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HumanCreator : MonoBehaviour
{
    enum Operation { Sum, Multiplication };
    [SerializeField] Operation operation;
    [SerializeField] float value;
    [SerializeField] TMP_Text text;
    HumanCreatorController humanCreatorController;
    float count;
    private void Start()
    {
        humanCreatorController = transform.parent.GetComponent<HumanCreatorController>();
        if (operation == Operation.Sum)
        {
            text.text = "+";
        }
        else if (operation == Operation.Multiplication)
        {
            text.text = "x";
        }
        text.text += value.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        float randomPositionRange = 0.5f;
        if (!humanCreatorController.GetIsTaken())
        {
            Transform parent = other.transform.parent;
            if (operation == Operation.Sum)
            {
                count = value;
            }
            else if (operation == Operation.Multiplication)
            {
                count = parent.GetComponent<TeamLeader>().humanCount * value;
            }
            for (int i = 0; i < count; i++)
            {
                Vector3 position = new Vector3(Random.Range(parent.position.x - randomPositionRange, parent.position.x + randomPositionRange),
                                                parent.position.y,
                                                Random.Range(parent.position.z - randomPositionRange, parent.position.z + randomPositionRange));

                GameObject human = ObjectPooler.SharedInstance.GetPooledObject(Constants.HUMAN_TAG);
                human.transform.position = position;
                human.transform.SetParent(parent);
                human.GetComponent<TeamMember>().JoinTeam();
                human.SetActive(true);
            }
            humanCreatorController.Take();
        }
    }
}
