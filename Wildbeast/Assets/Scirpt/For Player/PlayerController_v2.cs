using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_v2 : MonoBehaviour
{
    //movement variables setting

    public float intSpeed = 5f;
    public float walkSpeed = 0;
    public float rushSpeed = 5f;
    public float turnSpeed = 50f;



    Rigidbody myRB;
    public Animator myAnim;

    //jump function
    bool onGround = false;
    Collider[] groundCollisions;
    float groundCheckRadius = 5f;
    public LayerMask groundLayer;
    public Transform groundChecker;
    public float jumpForce = 1f;

    bool IsMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        //myAnim = GetComponent<Animator>();
        walkSpeed = intSpeed;
    }

    //physical movement:
    void FixedUpdate()
    {
        // walk function
        float move = Input.GetAxis("Vertical");
        myAnim.SetFloat("speed", Mathf.Abs(move));
        // rush function
        float rush = Input.GetAxisRaw("Fire3");
        myAnim.SetFloat("rush", Mathf.Abs(rush));
        //jump function
        if (onGround && Input.GetAxis("Jump") > 0)
        {
            onGround = false;
            myAnim.SetBool("onGround", onGround);
            myRB.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }

        groundCollisions = Physics.OverlapSphere(groundChecker.position, groundCheckRadius, groundLayer);

        if (groundCollisions.Length > 0)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }

        myAnim.SetBool("onGround", onGround);


        //movement function
        if (Input.GetAxisRaw("Fire3") > 0)
        {
            walkSpeed = rushSpeed;
        }
        else
        {
            walkSpeed = intSpeed;
        }
        //for movement
        if (Input.GetKey(KeyCode.W) && onGround)
        {
            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) && onGround)
        {
            transform.Translate(-Vector3.right * walkSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) && onGround)
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) && onGround)
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

    }


}
