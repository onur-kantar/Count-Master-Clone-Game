using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeamLeader : MonoBehaviour
{
    public Manager manager;
    [SerializeField] TMP_Text humanCountText;
    [HideInInspector] public int humanCount;
    int finishedHumanCount;

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
