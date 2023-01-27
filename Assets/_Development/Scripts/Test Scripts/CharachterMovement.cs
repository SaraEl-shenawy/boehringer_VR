using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class CharachterMovement : MonoBehaviour
{
    Coroutine rotationCoroutine;
    Rigidbody rb;
    public float SpeedFactor = .1f;
    public Vector3 point;
    bool isPressed = false;
    float speed = 1000;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            isPressed = true;
            rotationCoroutine = StartCoroutine(GetDirectionLeft());
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            isPressed = true;
            rotationCoroutine = StartCoroutine(GetDirectionRight());
        }

        if (Input.GetKeyUp(KeyCode.Keypad1) || Input.GetKeyUp(KeyCode.Keypad3))
        {
            isPressed = false;
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3();
        movement.x = moveHorizontal;
        movement.z = moveVertical;
        rb.AddForce(movement * speed * Time.deltaTime);

    }


    IEnumerator GetDirectionLeft()
    {
        while (isPressed)
        {
            yield return new WaitForEndOfFrame();
            transform.RotateAround(point, Vector3.up, 20 * Time.deltaTime);
        }
    }
    IEnumerator GetDirectionRight()
    {
        while (isPressed)
        {
            yield return new WaitForEndOfFrame();
            transform.RotateAround(point, -Vector3.up, 20 * Time.deltaTime);
        }
    }
}

