using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class SearchTarget : Conditional
{
    public Transform PlayerView;
    public float searchAngle = 45;
    public int searchLine = 5;
    public int Times = 2;
    public float searchDistance;
    public List<GameObject> Searched = new List<GameObject>();

    public override TaskStatus OnUpdate()
    {
        RaycastHit ray;
        Searched = new List<GameObject>();
        for (int i = 0; i < Times; i++)
        {
            for (int j = 0; j < searchLine; j++)
            {
                PlayerView.localEulerAngles = Vector3.zero;
                PlayerView.Rotate(Vector3.forward * (360 / Times) * i);
                PlayerView.Rotate(Vector3.up * searchAngle * (j / (float)searchLine));
                if (Physics.Raycast(PlayerView.position, PlayerView.forward, out ray, searchDistance))
                {
                 //   Gizmos.DrawLine(PlayerView.position, ray.point);
                    if (!Searched.Contains(ray.transform.gameObject))
                    {
                        Searched.Add(ray.transform.gameObject);
                        foreach (GameObject searched in Searched)
                        {
                            if (searched.GetComponent<BossComponent>())
                            {
                               
                                return TaskStatus.Success;
                            }
                        }
                    }
                }
               
                
            }

        }
        return TaskStatus.Failure;

    }
}

