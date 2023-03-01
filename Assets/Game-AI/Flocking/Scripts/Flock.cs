using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public float cohesionWeight;
    public float seperationWeight;
    public float alignmentWeight;

    [SerializeField]
    float fishCount = 20;
    [SerializeField]
    Vector3 tankLimits = new Vector3(5, 5, 5);
    [SerializeField]
    Transform target;

    [SerializeField]
    GameObject[] fish;

    private void Awake()
    {
        for (int i = 0; i < fishCount; i++)
        {
            GameObject fishInstance = Instantiate(fish[Random.Range(0, fish.Length)], transform);
            fishInstance.transform.localPosition = new Vector3(Random.Range(-tankLimits.x, tankLimits.x),
                Random.Range(-tankLimits.y, tankLimits.y),
                Random.Range(-tankLimits.z, tankLimits.z));
            fishInstance.AddComponent<Seek>().target = target;
        }
    }

    public List<Transform> GetFlock(GameObject other)
    {
        List<Transform> flock = new List<Transform>();

        foreach (Transform child in transform)
        {
            if (other != child.gameObject)
                flock.Add(child);
        }

        return flock;
    }
}
