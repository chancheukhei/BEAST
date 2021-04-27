using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //movement variables setting

    public float walkSpeed = 5f;
    public float rushSpeed = 10f;

    Rigidbody myRB;
    public Animator myAnim;
    bool facingRight;
    bool facingUp;
    //jump function
    bool onGround = false;
    Collider[] groundCollisions;
    float groundCheckRadius = 5f;
    public LayerMask groundLayer;
    public Transform groundChecker;
    public float jumpForce = 1f;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        //myAnim = GetComponent<Animator>();
        facingRight = true;
        facingUp = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //physical movement:
    void FixedUpdate()
    {
        // walk function
        float move = Input.GetAxis("Horizontal");
        float move2 = Input.GetAxis("Vertical");
        myAnim.SetFloat("speed", Mathf.Abs(move));
        myAnim.SetFloat("speed", Mathf.Abs(move2));
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

        //fireLaser function
        float firing = Input.GetAxis("Fire1");
        myAnim.SetFloat("shooting", firing);
        //movement function

        //for Horizontal movement
        if ((move > 0 || move2 > 0 || firing > 0) && onGround)
        {
            myRB.velocity = new Vector3(move * walkSpeed, myRB.velocity.y, move2 * walkSpeed);
        }
        else
        {
            myRB.velocity = new Vector3(move * rushSpeed, myRB.velocity.y, move2 * rushSpeed);
        }
        //flip function
        if (move > 0 && !facingRight)
        {
            FlipRight();
        }
        else if (move < 0 && facingRight)
        {
            FlipLeft();
        }
    }

    void FlipRight()
    {
        facingRight = !facingRight;
        /*
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        */
        transform.Rotate(0, 0, 0, Space.Self);

    }
    void FlipLeft()
    {
        facingRight = !facingRight;
        /*
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
        transform.localRotation = Quaternion.Euler(180f, 180f, -180f);
        */
        transform.Rotate(0, 180, 0, Space.Self);
    }

    void FlipUp()
    {
        facingUp = !facingUp;
        transform.Rotate(0, -90, 0, Space.Self);
    }
    void FlipDown()
    {
        facingUp = !facingUp;
        transform.Rotate(0, 90, 0, Space.Self);
    }



    public float GetFacing()
    {
        if (facingRight) return 1;
        else return -1;
    }
}
