using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alignment : MonoBehaviour, ISteer
{
    [HideInInspector]
    public Flock flock;

    public Vector3 GetForce()
    {
        if (flock == null)
            flock = GetComponentInParent<Flock>();

        Vector3 force = Vector3.zero;
        int flockCont = 0;
        List<Transform> flockList = flock.GetFlock(gameObject);

        //TODO: Alignment
        foreach (Transform child in flockList)
        {
            if(child.gameObject !=gameObject)
            {
                force += child.GetComponent<Rigidbody>().velocity;
                flockCont++;
            }
        }
        if (flockCont > 0)
        {
            force /= flockCont;
        }

        return force * flock.alignmentWeight;
    }
}
