using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_v2 : MonoBehaviour
{
    //movement variables setting

    public float intSpeed = 4f;
    public float intRushSpeed = 7f;
    float walkSpeed;
    float rushSpeed;
    public float turnSpeed = 50f;

    public float airSpeed;

    float jumpTime;
    public float nextJump;

    Rigidbody myRB;
    public Animator myAnim;

    //jump function
    bool onGround = true;
    public float jumpForce;
    public float power;

    bool IsMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        //myAnim = GetComponent<Animator>();
        SetRushSpeed(intRushSpeed);
        jumpTime = 0;
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
        myAnim.SetBool("onGround", onGround);
        if (onGround && (Input.GetAxisRaw("Jump") > 0) && Time.time > jumpTime)
        {
            onGround = false;
            jumpTime = Time.time + nextJump;
            myRB.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }

        //movement function
        if (Input.GetAxisRaw("Fire3") > 0)
        {
            walkSpeed = GetRushSpeed();
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
        else if (Input.GetKey(KeyCode.W) && !onGround)
        {
            //transform.Translate(Vector3.right * airSpeed * Time.deltaTime);
            transform.Translate(Vector3.right * airSpeed * power * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) && onGround)
        {
            transform.Translate(-Vector3.right * walkSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) && !onGround)
        {
            transform.Translate(-Vector3.right * airSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) && onGround)
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) && !onGround)
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) && onGround)
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) && !onGround)
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }

    }

    void OnCollisionStay()
    {
        onGround = true;
    }

    public void SetRushSpeed(float speed)
    {
        rushSpeed = speed;
    }

    public float GetRushSpeed()
    {
        return rushSpeed;
    }

}
