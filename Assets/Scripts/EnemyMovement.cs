using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyLogic))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int waypointCounter = 0; // 0 to 9

    private EnemyLogic enemy;

    void Start()
    {
        enemy = GetComponent<EnemyLogic>();

        target = WaypointLogic.waypoints[0]; // first waypoint on the road of an enemy
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f) // update waypoint once close enough (start moving towards the next waypoint on the road)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypoint()
    {
        if (waypointCounter >= WaypointLogic.waypoints.Length - 1)
        {
            EndPath();
            return;
        }

        waypointCounter++;
        target = WaypointLogic.waypoints[waypointCounter];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
