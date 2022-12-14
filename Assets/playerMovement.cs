using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Camera cam;
    public PlayerAudio playerAudio;
    public float moveSpeed;
    public Rigidbody2D rb;
    public GameObject reticle;
    public float inputDeadZone;
    public float lookDeadZone;
    public PlayerAttack PlayerAttack;

    private Vector3 moveDirection;
    private Vector3 lookDirection;
    private Vector3 lastLook = Vector3.zero;
    private float fire;

    private void Start()
    {
        playerAudio = GetComponent<PlayerAudio>();
        PlayerAttack = GetComponent<PlayerAttack>();
    }

    void HandleMoveAudio(bool isMoving)
    {
        if (isMoving && !playerAudio.WalkSource.isPlaying)
        {

            //Debug.Log("moving");
            playerAudio.WalkSource.Play();
        }
        else if (!isMoving && playerAudio.WalkSource.isPlaying)
        {
            //Debug.Log("stopping");
            playerAudio.WalkSource.Pause();
        }
    }

    void HandleAttackAudio()
    {
        if (!playerAudio.AttackSource.isPlaying) { 
            playerAudio.AttackSource.Play();
        }
        else
        {
            playerAudio.AttackSource.Stop();
            playerAudio.AttackSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
        Aim();
        Fire();
    }

    void ProcessInputs()
    {
        float lookX = Input.GetAxis("RightStickHorizontal");
        float lookY = Input.GetAxis("RightStickVertical");

        float moveX = Input.GetAxis("LeftStickHorizontal");
        float moveY = Input.GetAxis("LeftStickVertical");

        //debug
        fire = Input.GetAxisRaw("Fire");
        //Debug.Log("fire: " + fire);

        moveDirection = new Vector3(moveX, moveY, 0);
        if (new Vector3(lookX, lookY, 0).magnitude < lookDeadZone)
        {
            lookDirection = Vector3.zero;
        }
        else
        {
            lookDirection = new Vector3(lookX, lookY, 0).normalized;
            lastLook = lookDirection;
        }
        if (new Vector3(moveX, moveY, 0).magnitude < inputDeadZone)
        {
            moveDirection = Vector3.zero;
            HandleMoveAudio(false);
        }
        else
        {
            HandleMoveAudio(true);
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
            //lookDirection *= 0.5f;
            reticle.transform.localPosition = lookDirection;
        }
    }

    void Fire()
    {
        if (fire == 1)
        {
            if (lastLook == Vector3.zero)
            {
                return;
            }
            //Debug.Log("Look Magnitude: " + lookDirection.magnitude);
            //Debug.Log("LastLook Magnitude: " + lastLook.magnitude);
            if (lookDirection.magnitude >= 0.5)
            {
                //Debug.Log("shooting in look direction");
                if (PlayerAttack.Attack(lookDirection))
                {
                    HandleAttackAudio();
                }
            }
            else
            { 
                if (PlayerAttack.Attack(lastLook))
                {
                    HandleAttackAudio();
                }
            }
        }
    }
}