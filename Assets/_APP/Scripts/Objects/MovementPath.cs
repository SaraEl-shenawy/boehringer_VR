using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    [SerializeField] Waypoints way;
    public float speed = 5;
    private int next = 0;
    float targetY;
    float velocityTurn;

    void Start()
    {
        transform.position = way.WayPoints[0].position;
    }


    void Update()
    {
        if ((transform.position - way.WayPoints[next].position).sqrMagnitude < 0.01f)
        {
            next++;
            if (next >= way.WayPoints.Length)
            {
                next = 0;

            }
        }
        transform.position = Vector3.MoveTowards(transform.position, way.WayPoints[next].position, Time.deltaTime * speed);
        Vector3 Dir = (way.WayPoints[next].position - transform.position).normalized;
        //  Debug.Log(Dir);
        targetY = Mathf.Atan2(Dir.x, Dir.z) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetY, ref velocityTurn, 0.5f);

    }








}
