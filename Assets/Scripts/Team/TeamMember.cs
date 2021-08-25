using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamMember : MonoBehaviour
{
    [HideInInspector] public TeamLeader leader;
    List<TeammatePoint> teammatePoints;
    private void OnEnable()
    {
        if (transform.parent != null)
        {
            JoinTeam();
        }
    }
    public void JoinTeam()
    {
        leader = transform.parent.GetComponent<TeamLeader>();
        //leader.IncreaseHumanCount();

        teammatePoints = transform.parent.GetComponent<CreateTeamPoints>().teammatePoints;
        foreach (TeammatePoint teammatePoint in teammatePoints)
        {
            if (!teammatePoint.go)
            {
                teammatePoint.go = gameObject;
                GetComponent<MoveToTargetDirection>().target = teammatePoint.Point;
                //target = teammatePoint.Point;
                //mainPlayer.GetComponent<PlayerController>().IncreasePlayer();
                leader.IncreaseHumanCount();
                //Destroy(teammatePS);
                break;
            }
            //teamId++;
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
        //GetComponent<Rigidbody>().drag = 0;
        //GetComponent<Rigidbody>().useGravity = true;
        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        //Vector3 power;
        //power.x = Random.Range(-200, 200);
        //power.y = Random.Range(-200, 200);
        //power.z = Random.Range(-200, 200);
        //GetComponent<Rigidbody>().AddTorque(power);
        //GetComponent<Rigidbody>().AddForce(power);
        GetComponent<Animator>().SetTrigger("Fall");
        GetComponent<MoveToDirection>().enabled = false;
        leader.DecreaseHumanCount();

        foreach (TeammatePoint teammatePoint in teammatePoints)
        {
            if (teammatePoint.go == gameObject)
            {
                teammatePoint.go = null;
                break;
            }
        }
        yield return new WaitForSeconds(1);

        //Destroy(gameObject, 3);
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        GetComponent<MoveToDirection>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }
}
