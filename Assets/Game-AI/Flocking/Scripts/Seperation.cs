using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seperation : MonoBehaviour, ISteer
{
    [HideInInspector]
    public Flock flock;
    [SerializeField]
    float inRange = 2;
    Vector3 dir;

    public Vector3 GetForce()
    {
        if (flock == null)
            flock = GetComponentInParent<Flock>();

        Vector3 force = Vector3.zero;

        List<Transform> flockList = flock.GetFlock(gameObject);
        int flockCount = 0;

        //TODO: Seperation

        foreach (Transform child in flockList)
        {
            if (child.gameObject != gameObject)
            {
                if (Vector3.Distance(child.position, transform.position) < inRange)
                {
                    force += transform.position - child.position;
                    flockCount++;
                }
            }
        }
        if (flockCount > 0)
        {

            force /= flockCount;
        }

        return force.normalized * flock.seperationWeight;
    }
}
