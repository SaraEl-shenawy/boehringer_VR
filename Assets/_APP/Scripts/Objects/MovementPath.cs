using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    private Transform targetWaypoint;
    private int TargetWaypointIndex = 0;
    private float MinDistance = 0.1f;
    private int LastWaypointIndex;

    public float MovementSpeed = 10.0f;
    private float RotationSpeed = 8.0f;

    void Start()
    {
        LastWaypointIndex = waypoints.Length - 1;
        targetWaypoint = waypoints[TargetWaypointIndex];
    }


    void Update()
    {
        float movementStep = MovementSpeed * Time.deltaTime;
        float rotationStep = RotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);

        Debug.DrawRay(transform.position, transform.forward * 50f, Color.green, 0f);
        Debug.DrawRay(transform.position, directionToTarget, Color.red, 0f);

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);
    }


    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (currentDistance <= MinDistance)
        {
            TargetWaypointIndex++;
            UpdateTargetWaypoint();
        }
    }


    void UpdateTargetWaypoint()
    {
        if (TargetWaypointIndex > LastWaypointIndex)
        {
            TargetWaypointIndex = 0;
        }

        targetWaypoint = waypoints[TargetWaypointIndex];
    }

    private void OnDrawGizmos()
    {
        if (waypoints == null)
            return;
        for (int i = 0; i < waypoints.Length; i++)
        {
            Gizmos.DrawSphere(waypoints[i].position, 0.2f);

            if (i + 1 < waypoints.Length)
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
        }
    }
}
