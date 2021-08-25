using System.Collections.Generic;
using UnityEngine;

public class CreateTeamPoints : MonoBehaviour
{
    [SerializeField] GameObject player;
    public List<TeammatePoint> teammatePoints;

    void Awake()
    {
        CreateWithSinAndCos();
    }
    void CreateWithSinAndCos()
    {
        float layerCount = 8;
        float startAngle = 60;

        CalculateAndAddList(0, 0);
        for (int layer = 1; layer < layerCount; layer++)
        {
            float angle = startAngle / layer;
            for (float totalAngle = 0; totalAngle < 360; totalAngle += angle)
            {
                CalculateAndAddList(totalAngle, layer);
            }
        }
    }
    void CalculateAndAddList(float totalAngle, int layer)
    {
        float layerReduction = 4;
        TeammatePoint newTeammatePoint;
        GameObject go;

        float sinAngle = Mathf.Sin(totalAngle * Mathf.PI / 180);
        float cosAngle = Mathf.Cos(totalAngle * Mathf.PI / 180);

        newTeammatePoint = new TeammatePoint();
        newTeammatePoint.Point = new Vector3(sinAngle, 0, cosAngle) * layer / layerReduction;

        //go = Instantiate(player, transform.position + newTeammatePoint.Point, Quaternion.identity);
        //go.transform.parent = transform;

        teammatePoints.Add(newTeammatePoint);
    }
}
