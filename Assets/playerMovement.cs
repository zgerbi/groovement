using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Camera cam;
    public float moveSpeed;
    public Rigidbody2D rb;
    public GameObject reticle;
    public float inputDeadZone;
    public float lookDeadZone;

    private Vector3 moveDirection;
    private Vector3 lookDirection;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
        Aim();
    }

    void ProcessInputs()
    {
        float lookX = Input.GetAxis("RightStickHorizontal");
        float lookY = Input.GetAxis("RightStickVertical");

        float moveX = Input.GetAxis("LeftStickHorizontal");
        float moveY = Input.GetAxis("LeftStickVertical");

        //debug
        //float fire = Input.GetAxisRaw("Fire");
        //Debug.Log("fire: " + fire);

        moveDirection = new Vector3(moveX, moveY, 0);
        if (new Vector3(lookX, lookY, 0).magnitude < lookDeadZone)
        { 
            lookDirection = Vector3.zero;
        }
        else
            lookDirection = new Vector3(lookX, lookY, 0).normalized;
        if (new Vector3(moveX, moveY, 0).magnitude < inputDeadZone)
        {
            moveDirection = Vector3.zero;
        }
        
    }

    void Move()
    {
        rb.transform.position = Vector2.MoveTowards(transform.position, transform.position + moveDirection, moveSpeed * Time.deltaTime);
    }

    void Aim()
    {
        if (lookDirection.magnitude > lookDeadZone)
        {
            lookDirection *= 0.5f;
            reticle.transform.localPosition = lookDirection;
        }
    }
}