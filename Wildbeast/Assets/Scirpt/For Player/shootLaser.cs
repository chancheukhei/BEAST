using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootLaser : MonoBehaviour
{
    //laser variables setting
    public float range = 10f;
    public float damge = 5f;

    Ray shootRay;
    RaycastHit hit;
    int shootableMask;
    LineRenderer laserLine;
    // Start is called before the first frame update
    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        laserLine = GetComponent<LineRenderer>();

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        laserLine.SetPosition(0, transform.position);

        if (Physics.Raycast(shootRay, out hit, range, shootableMask))
        {
            //hit an emeny goes here
            laserLine.SetPosition(1, hit.point);
        }
        else laserLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
