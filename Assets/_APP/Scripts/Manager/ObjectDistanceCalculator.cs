using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDistanceCalculator : MonoBehaviour
{
    [SerializeField] GameObject object1;
    [SerializeField] GameObject object2;
    [SerializeField] float distance;
    [SerializeField] ObjectDistanceCalculator nextDistanceCalculator;
    public UnityEvent OnReachDestination;
    void Update()
    {
        Vector2 pos1 = object1.transform.position;
        Vector2 pos2 = object2.transform.position;

        if (Vector3.Distance(pos1, pos2) < distance)
        {
            Debug.Log("Distance = " + distance);
            OnReachDestination.Invoke();
            nextDistanceCalculator.gameObject.GetComponent<ObjectDistanceCalculator>().enabled = true;
            this.gameObject.GetComponent<ObjectDistanceCalculator>().enabled = false;
        }
    }
}
