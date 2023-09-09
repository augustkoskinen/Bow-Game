using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask groundMask;
    public Transform orientation;
    public Transform camposition;
    public Transform bow;
    public Transform body;
    public Vector3 movedirection;
    Rigidbody rb;

    float horizontalinput;
    float verticalinput;

    public float movespeed;
    public float crouchspeed;
    public float runspeed;
    public float playerHeight = 2;
    public float grounddrag;
    public float airdrag;
    public float jumpcooldown;
    public float jumpforce;
    public float airmultiplier;

    bool isGrounded = true;
    bool canjump = true;

    public KeyCode jumpkey = KeyCode.Space;
    public KeyCode shiftkey = KeyCode.LeftShift;
    public KeyCode controlkey = KeyCode.LeftControl;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight*0.5f+0.2f,groundMask);

        MyInput();
        Speedcontrol();

        if (isGrounded)
            rb.drag = grounddrag;
        else
            rb.drag = airdrag;
        //print(rb.velocity);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalinput = Input.GetAxisRaw("Horizontal");
        verticalinput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpkey) && canjump && isGrounded)
        {
            Jump();
            canjump = false;
            Invoke(nameof(ResetJump), jumpcooldown);
        }
    }

    private void MovePlayer()
    {
        movedirection = orientation.forward * verticalinput + orientation.right * horizontalinput;
        var speed = movespeed;
        body.localScale = new Vector3(1f, 1f, 1f);
        body.localPosition = new Vector3(0, 0f, 0f);
        orientation.localPosition = new Vector3(0f, 0f, 0f);
        bow.SetLocalPositionAndRotation(new(0.8f, -0.703f, 1), Quaternion.Euler(0, 0, 0));
        if (Input.GetKey(shiftkey))
        {
            speed = runspeed;
        }
        else if (Input.GetKey(controlkey))
        {
            speed = crouchspeed;

            body.localScale = new Vector3(1f, .5f, 1f);
            body.localPosition = new Vector3(0, -.5f, 0f);
            orientation.localPosition = new Vector3(0f, -1f, 0f);
            bow.SetLocalPositionAndRotation(new(0.8f, -.5f, 1), Quaternion.Euler(0, 0, 67));
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            speed = crouchspeed;
        }

            if (isGrounded)
            rb.AddForce(10f * speed * movedirection.normalized, ForceMode.Force);
        else
            rb.AddForce(10f * airmultiplier * speed * movedirection.normalized, ForceMode.Force);

    }

    private void Speedcontrol()
    {
        Vector3 flatvel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatvel.magnitude > movespeed){
            Vector3 limitedvel = flatvel.normalized * movespeed;
            rb.velocity = new Vector3(limitedvel.x, rb.velocity.y, limitedvel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpforce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        canjump = true;
    }
}

