using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public static Transform[] ActiveWaypoints;

    private void Awake()
    {
        ActiveWaypoints = new Transform[this.transform.childCount];

        for(int waypointIndex = 0; waypointIndex < ActiveWaypoints.Length; waypointIndex++)
        {
            ActiveWaypoints[waypointIndex] = this.transform.GetChild(waypointIndex);
        }

    }
}
