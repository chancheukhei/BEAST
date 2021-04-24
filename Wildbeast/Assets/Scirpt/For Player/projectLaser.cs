﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectLaser : MonoBehaviour
{
    //variables setting
    public float timeBetweenLaser = 0.15f;
    public GameObject projectile;
    public AudioClip hitSound;
    float nextLaser;
       
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Awake()
    {
        nextLaser = 0f;
    }

    void Update()
    {
        playerController thePlayer = transform.root.GetComponent<playerController>();

        if (Input.GetAxisRaw("Fire1") > 0 && nextLaser < Time.time)
        {
            audio.PlayOneShot(hitSound);
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
