using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonceOffMe : MonoBehaviour
{
    AudioSource bonceSound;
    void Start()
    {
        bonceSound = GameObject.FindWithTag("boncer").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.transform.position = col.gameObject.transform.position*2;
            bonceSound.Play();
        }
    }
}
