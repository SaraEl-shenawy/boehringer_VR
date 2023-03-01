using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohesion : MonoBehaviour, ISteer
{
    [HideInInspector]
    public Flock flock;
    Rigidbody rb;
    [SerializeField]
    float inRange = 2;
    [SerializeField]
    Vector3 dir;
    public Vector3 GetForce()
    {
        if (flock == null)
            flock = GetComponentInParent<Flock>();
        Vector3 force = Vector3.zero;

        List<Transform> flockList = flock.GetFlock(gameObject);
        int flockCount = 0;

        //TODO: Cohesion
        foreach (Transform child in flockList)
        {
            if (child.gameObject !=gameObject)
            {
                
                    force += child.position;
                    flockCount++;
                
            }
        }

        if (flockCount > 0)
        {
            force /= flockCount;
             dir = force - transform.position;
        }
        return dir.normalized * flock.cohesionWeight;
    }
}
