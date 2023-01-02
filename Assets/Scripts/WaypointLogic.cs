using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointLogic : MonoBehaviour
{
    public static Transform[] waypoints;
    void Awake() // Start()
    {
        waypoints = new Transform[transform.childCount]; // 9 waypoints
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        
    }
}
