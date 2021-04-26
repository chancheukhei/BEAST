using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectLaser : MonoBehaviour
{
    //variables setting
    public float timeBetweenLaser = 0.15f;
    public GameObject projectile;

    float nextLaser;
    // Start is called before the first frame update
    void Awake()
    {
        nextLaser = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        playerController thePlayer = transform.root.GetComponent<playerController>();

        if (Input.GetAxisRaw("Fire1") > 0 && nextLaser < Time.time)
        {
            nextLaser = Time.time + timeBetweenLaser;
            Vector3 rotation;
            if (thePlayer.GetFacing() == -1f)
            {
                rotation = new Vector3(0f, -90f, 0);
            }
            else
            {
                rotation = new Vector3(0f, 90f, 0f);
            }

            Instantiate(projectile, transform.position, Quaternion.Euler(rotation));
        }
    }
}
