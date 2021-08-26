using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeamLeader : MonoBehaviour
{
    public GameManager manager;
    [SerializeField] TMP_Text humanCountText;
    [SerializeField] int defaultHumanCount;
    [HideInInspector] public int humanCount;
    int finishedHumanCount;
    private void Start()
    {
        CreateDefaultHuman();
    }
    void CreateDefaultHuman()
    {
        for (int i = 0; i < defaultHumanCount; i++)
        {
            GameObject human = ObjectPooler.SharedInstance.GetPooledObject(Constants.HUMAN_TAG);
            human.transform.position = transform.position;
            human.transform.SetParent(transform);
            human.GetComponent<TeamMember>().JoinTeam();
            human.SetActive(true);
        }
    }
    public void IncreaseFinishedHumanCount()
    {
        finishedHumanCount++;
        if (finishedHumanCount == humanCount)
        {
            GetComponent<BuildTower>().enabled = false;
            manager.Win();
        }
    }
    public void IncreaseHumanCount()
    {
        humanCount++;
        UpdateText();
    }
    public void DecreaseHumanCount()
    {
        humanCount--;
        UpdateText();
        if (humanCount == 0)
        {
            manager.Lose();
        }
    }
    void UpdateText()
    {
        humanCountText.text = humanCount.ToString();
    }
    public void TextActiveFalse()
    {
        humanCountText.gameObject.SetActive(false);
    }
}
