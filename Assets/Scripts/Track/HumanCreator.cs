using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HumanCreator : MonoBehaviour
{
    enum Operation { Sum, Multiplication };
    [SerializeField] GameObject human;
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
                Vector3 position = new Vector3(Random.Range(parent.position.x - 0.5f, parent.position.x + 0.5f),
                                                parent.position.y,
                                                Random.Range(parent.position.z - 0.5f, parent.position.z + 0.5f));

                GameObject human = ObjectPooler.SharedInstance.GetPooledObject("Human");
                if (human != null)
                {
                    human.transform.position = position;
                    human.SetActive(true);
                }
                //GameObject go = Instantiate(this.human, position, Quaternion.identity);
                human.transform.SetParent(parent);
                human.GetComponent<TeamMember>().JoinTeam();
            }
            humanCreatorController.Take();
        }
    }
}
