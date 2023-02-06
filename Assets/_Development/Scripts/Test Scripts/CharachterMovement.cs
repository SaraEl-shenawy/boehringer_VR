using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class CharachterMovement : MonoBehaviour
{
    Coroutine moveCoroutine;
    Rigidbody rb;
    public float SpeedFactor = .1f;
    public Vector3 point;
    bool isPressed = false;
    float speed = 1000;

    private Animator animator;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = this.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            moveCoroutine = StartCoroutine(MovePlayer(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        }
        if (Input.GetAxisRaw("Horizontal") == 0 || Input.GetAxisRaw("Vertical") == 0)
        {
            animator.SetFloat("Speed", 0);
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetFloat("Speed", 0.5f);
        }
    }
    IEnumerator MovePlayer(float _horizontalMove, float _VerticalMove)
    {
        yield return new WaitForEndOfFrame();
        transform.Translate(_horizontalMove * SpeedFactor, 0, Input.GetAxisRaw("Vertical") * SpeedFactor);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fishing")
        {
            Debug.Log("Fish");
            animator.SetTrigger("Fishing");
        }
    }
}

