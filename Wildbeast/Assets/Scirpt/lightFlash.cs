using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFlash : MonoBehaviour
{

    public bool lightOn = true;       // light swich
    public float turnspeed = 5;  // light flashing speed
    private float highIntensity = 20f;
    private float lowIntensity = 5;
    private float targetIntensity = 5;
    private Light flashLight;

    void Start()
    {
        // get light component
        flashLight = GameObject.FindWithTag("flashLight").GetComponent<Light>();
        
        // set target light intensity to high
        targetIntensity = highIntensity;
    }

    void Update()
    {
        // if turn on the light, light flashing
        if (lightOn)
        {
            // swich intensity to high
            flashLight.intensity = Mathf.Lerp(flashLight.intensity, targetIntensity, Time.deltaTime * turnspeed);
            if (Mathf.Abs(targetIntensity - flashLight.intensity) <= 0.05f)
            {
                targetIntensity = targetIntensity == highIntensity ? lowIntensity : highIntensity;
            }
        }
        else
        {
            // swich light to low intensity
            flashLight.intensity = Mathf.Lerp(flashLight.intensity, lowIntensity, Time.deltaTime * turnspeed);

            if (flashLight.intensity < 0.1f)
            {
                flashLight.intensity = lowIntensity;
            }
        }
            
    }
}
