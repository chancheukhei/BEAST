using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //movement variables setting
    public float walkSpeed = 5f;
    public float rushSpeed = 10f;

    Rigidbody myRB;
    Animator myAnim;
    bool facingRight;
    //jump function
    bool onGround = false;
    Collider[] groundCollisions;
    float groundCheckRadius = 4.5f;
    public LayerMask groundLayer;
    public Transform groundChecker;
    public float jumpForce = 1f;
    public AudioClip jumpSound;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        facingRight = true;
        audio = GetComponent<AudioSource>();

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
            audio.PlayOneShot(jumpSound);
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
        //for rush movement

        if ((move > 0 || firing > 0) && onGround)
        {
            myRB.velocity = new Vector3(move * walkSpeed, myRB.velocity.y, 0f);
        }
        //for walk movement
        else
        {
            myRB.velocity = new Vector3(move * rushSpeed, myRB.velocity.y, 0f);
        }
        //flip function
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scale = transform.localScale;
        Scale.y *= -1;
        transform.localScale = Scale;
    }

    public float GetFacing()
    {
        if (facingRight) return 1;
        else return -1;
    }
}
