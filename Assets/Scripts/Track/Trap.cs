using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] float stepToGo;
    [SerializeField] float moveDuration;
    private void Start()
    {
        transform.DOLocalMoveX(transform.position.x + stepToGo, moveDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

    }
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<TeamMember>().LeaveTeam();
    }
}
