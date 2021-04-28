using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject player;
    PlayerController_v2 playerScript;
    projectLaser playerShoot;
    [Header("Ability 1")]
    public Image abilityImage_1;
    public float cooldown_1 = 10;
    bool isCooldown_1 = false;
    public KeyCode ability_1;

    [Header("Ability 2")]
    public Image abilityImage_2;
    public float cooldown_2 = 10;
    bool isCooldown_2 = false;
    public KeyCode ability_2;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        playerScript = player.GetComponent<PlayerController_v2>();
        playerShoot = player.GetComponentInChildren<projectLaser>();
        abilityImage_1.fillAmount = 0;
        abilityImage_2.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ability_1();
        Ability_2();
    }

    void Ability_1()
    {
        if (Input.GetKey(ability_1) && isCooldown_1 == false)
        {
            isCooldown_1 = true;
            abilityImage_1.fillAmount = 1;
            audioSource.Play();
        }
        if (isCooldown_1)
        {
            abilityImage_1.fillAmount -= 1 / cooldown_1 * Time.deltaTime;
            if (abilityImage_1.fillAmount <= 0)
            {
                abilityImage_1.fillAmount = 0;
                isCooldown_1 = false;
            }
            if (abilityImage_1.fillAmount >= 0.6)
            {
                playerShoot.setTimeBetweenLaser(0.15f);
                playerShoot.setRemainingRounds(20);
            }
            else if (abilityImage_1.fillAmount <= 0.5f)
            {
                playerShoot.setTimeBetweenLaser(playerShoot.intTimeBetweenLaser);
                playerShoot.setRemainingRounds(20);
            }
        }
    }

    void Ability_2()
    {
        if (Input.GetKey(ability_2) && isCooldown_2 == false)
        {
            isCooldown_2 = true;
            abilityImage_2.fillAmount = 1;
            audioSource.Play();
        }
        if (isCooldown_2)
        {
            abilityImage_2.fillAmount -= 1 / cooldown_2 * Time.deltaTime;
            if (abilityImage_2.fillAmount <= 0)
            {
                abilityImage_2.fillAmount = 0;
                isCooldown_2 = false;
            }
            if (abilityImage_2.fillAmount >= 0.5)
            {
                playerScript.SetRushSpeed(12);
            }
            else
            {
                playerScript.SetRushSpeed(playerScript.intRushSpeed);
            }
        }

    }
}
