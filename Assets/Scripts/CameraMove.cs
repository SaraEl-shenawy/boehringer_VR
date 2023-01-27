using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Player;
    private Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - Player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Player.transform.position + distance;
    }

   
}
