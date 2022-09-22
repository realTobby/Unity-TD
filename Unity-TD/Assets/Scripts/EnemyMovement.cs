using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed = 10f;

    private Transform CurrentTargetWaypoint;
    private int CurrentWaypointIndex = 0;

    private void Start()
    {
        GetNextWaypoint();
    }

    private void GetNextWaypoint()
    {
        if(CurrentWaypointIndex >= WaypointManager.ActiveWaypoints.Length)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            CurrentTargetWaypoint = WaypointManager.ActiveWaypoints[CurrentWaypointIndex];
            CurrentWaypointIndex += 1;
            this.transform.LookAt(CurrentTargetWaypoint);
        }

        
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 dir = CurrentTargetWaypoint.position - this.transform.position;
        this.transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(this.transform.position, CurrentTargetWaypoint.position) <= 0.2f)
        {
            GetNextWaypoint();
        }


    }
}
