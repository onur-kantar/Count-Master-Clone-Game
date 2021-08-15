using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamMember : MonoBehaviour
{
    [HideInInspector] public TeamLeader leader;
    private void Awake()
    {
        if (transform.parent != null)
        {
            JoinTeam();
        }
    }
    public void JoinTeam()
    {
        leader = transform.parent.GetComponent<TeamLeader>();
        leader.IncreaseHumanCount();
    }
    public void LeaveTeam()
    {
        transform.parent = null;
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<Rigidbody>().drag = 0;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        Vector3 power;
        power.x = Random.Range(-200, 200);
        power.y = Random.Range(-200, 200);
        power.z = Random.Range(-200, 200);
        GetComponent<Rigidbody>().AddTorque(power);
        GetComponent<Rigidbody>().AddForce(power);

        GetComponent<MoveToDirection>().enabled = false;
        leader.DecreaseHumanCount();

        Destroy(gameObject, 3);
    }
}
