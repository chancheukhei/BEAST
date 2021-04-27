using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class projectLaser : MonoBehaviour
{
    //variables setting
    public float timeBetweenLaser = 0.15f;
    public GameObject projectile;
    float nextLaser;

    //bullet info
    public Slider playerAmmoSlider;
    public int maxRound;
    public int startingRounds;
    int remainingRounds;
    public AudioClip bubbles;

    public float reloadingTime = 2f;

    float nextReload;

    AudioSource bubbleSound;

    void Start()
    {

    }


    // Start is called before the first frame update
    void Awake()
    {
        nextLaser = 0f;
        remainingRounds = startingRounds;
        playerAmmoSlider.maxValue = maxRound;
        playerAmmoSlider.value = remainingRounds;
        bubbleSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        playerController thePlayer = transform.root.GetComponent<playerController>();

        if (Input.GetKeyDown(KeyCode.R) && Time.time > nextReload)
        {
            nextReload = Time.time + reloadingTime;
            addbullet(5);
            playerAmmoSlider.value = remainingRounds;
        }

        if (Input.GetAxisRaw("Fire1") > 0 && Input.GetAxisRaw("Fire3") < 1 && nextLaser < Time.time && remainingRounds > 0)
        {
            nextLaser = Time.time + timeBetweenLaser;


            Instantiate(projectile, transform.position, transform.rotation);

            remainingRounds -= 1;
            playerAmmoSlider.value = remainingRounds;
            bubbleSound.Play();
        }
    }

    void addbullet(int round)
    {
        remainingRounds += round;
        if (remainingRounds > maxRound) remainingRounds = maxRound;

    }
}
