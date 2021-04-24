using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyMe : MonoBehaviour
{
    //laser variables setting
    public float lifeTime;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }
}
