using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = 0.5f;
    public Vector3 deltaMove;
    public float speed = 1;
    public GameObject mover;
    Coroutine rotationCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            rotationCoroutine = StartCoroutine(RotatePlayer(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));
        }
    }

    IEnumerator RotatePlayer(float _horizontalRotate, float _verticalRotate)
    {
        yield return new WaitForEndOfFrame();
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        //turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        mover.transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        //transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
    }
}
