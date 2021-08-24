using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BuildTower : MonoBehaviour
{
    List<int> towerCountList;
    List<GameObject> towerList;
    CameraMovement camAnims;
    bool move;

    private void Start()
    {
        towerCountList = new List<int>();
        towerList = new List<GameObject>();
        camAnims = Camera.main.transform.parent.GetComponent<CameraMovement>();
    }
    void Update()
    {
        if (move)
        {
            transform.GetComponent<Movement>().Move(Vector3.forward);
        }
    }
    public  void Build()
    {
        GetComponent<TeamLeader>().TextActiveFalse();
        GetComponent<MoveToDirection>().enabled = false;
        FillTowerList();
        StartCoroutine(BuildTowerCoroutine());
        camAnims.EndGameAnim(towerList[0].transform);
    }
    void FillTowerList()
    {
        int humanCount = GetComponent<TeamLeader>().humanCount;
        int rowMaxHumanCount = 5;

        for (int i = 1; i <= rowMaxHumanCount; i++)
        {
            if (humanCount < i)
            {
                break;
            }
            humanCount -= i;
            towerCountList.Add(i);
        }
        for (int i = rowMaxHumanCount; i > 0; i--)
        {
            if (humanCount >= i)
            {
                humanCount -= i;
                towerCountList.Add(i);
                i++;
            }
        }
        towerCountList.Sort();
    }
    IEnumerator BuildTowerCoroutine()
    {
        int towerId = 0;
        Vector3 sum;
        GameObject tower;
        float tempTowerHumanCount;
        transform.position = new Vector3(0, transform.position.y, transform.position.z);

        foreach (int towerHumanCount in towerCountList)
        {
            foreach (GameObject child in towerList)
            {
                child.transform.localPosition += Vector3.up;
            }
            tower = new GameObject("Tower" + towerId);
            tower.transform.parent = transform;
            tower.transform.localPosition = new Vector3(0, 0, 0);
            towerList.Add(tower);
            sum = Vector3.zero;
            tempTowerHumanCount = 0;
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                if (child.CompareTag("Human"))
                {
                    child.GetComponent<Collider>().isTrigger = true;
                    child.GetComponent<MoveToDirection>().enabled = false;
                    child.transform.parent = tower.transform;
                    child.transform.localPosition = new Vector3(tempTowerHumanCount / 2, 0, 0);
                    sum += child.transform.position;
                    tempTowerHumanCount++;
                    i--;
                    if (tempTowerHumanCount >= towerHumanCount)
                    {
                        break;
                    }
                }
            }
            tower.transform.position = new Vector3(-sum.x / towerHumanCount, tower.transform.position.y, tower.transform.position.z);
            sum = Vector3.zero;
            towerId++;
            yield return new WaitForSeconds(0.1f);
        }
        move = true;
    }
}
