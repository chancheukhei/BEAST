using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootLaser : MonoBehaviour
{
    public float pushBackForce;
    bool enemyInRange;

    public float speed = 20;
    Rigidbody myRB;
    // Start is called before the first frame update
    void Start()
    {
        enemyInRange = false;

        myRB = GetComponentInParent<Rigidbody>();
        myRB.AddForce(transform.right * speed, ForceMode.Impulse);
        /*
        if (transform.rotation.y > 0)
        {
            myRB.AddForce(Vector3.right * speed, ForceMode.Impulse);
        }
        else
        {
            myRB.AddForce(Vector3.right * -speed, ForceMode.Impulse);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.layer == LayerMask.NameToLayer("Shootable") && obj.tag == "Enemy")
        {
            myRB.velocity = Vector3.zero;
            Destroy(gameObject);
            enemyInRange = true;
            pushBack(obj.transform);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyInRange = false;
        }
    }

    void pushBack(Transform obj)
    {
        Vector3 pushDirection = new Vector3(0, (obj.position.y - transform.position.y), 0).normalized;
        pushDirection *= pushBackForce;

        Rigidbody pushedRB = obj.GetComponent<Rigidbody>();
        pushedRB.velocity = Vector3.zero;
        pushedRB.AddForce(pushDirection, ForceMode.Impulse);
    }

}
