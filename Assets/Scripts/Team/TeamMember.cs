using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamMember : MonoBehaviour
{
    [HideInInspector] public TeamLeader leader;
    List<TeammatePoint> teammatePoints;

    public void JoinTeam()
    {
        GetComponent<MoveToDirection>().StartMoveToDirection();
        GetComponent<Movement>().StartMovement();
        GetComponent<Collider>().enabled = true;

        leader = transform.parent.GetComponent<TeamLeader>();
        teammatePoints = transform.parent.GetComponent<CreateTeamPoints>().teammatePoints;
        foreach (TeammatePoint teammatePoint in teammatePoints)
        {
            if (!teammatePoint.Go)
            {
                teammatePoint.Go = gameObject;
                GetComponent<MoveToTargetDirection>().target = teammatePoint.Point;
                leader.IncreaseHumanCount();
                break;
            }
        }
    }
    public void LeaveTeam()
    {
        StartCoroutine(LeaveTeamCoroutine());   
    }
    IEnumerator LeaveTeamCoroutine()
    {
        transform.parent = null;
        GetComponent<Collider>().enabled = false;
        GetComponent<Animator>().SetTrigger(Constants.FALL_ANIM);
        GetComponent<MoveToDirection>().StopMoveToDirection();
        GetComponent<Movement>().StopMovement();
        leader.DecreaseHumanCount();

        foreach (TeammatePoint teammatePoint in teammatePoints)
        {
            if (teammatePoint.Go == gameObject)
            {
                teammatePoint.Go = null;
                break;
            }
        }

        yield return new WaitForSeconds(1);

        gameObject.SetActive(false);
    }

}
