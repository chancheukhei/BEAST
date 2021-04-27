using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    public GameObject playerDeathFX;
    public Slider playerHealthSlider;
    public Image damage_Indicator_Image;
    Color flashColor = new Color(202f, 104f, 160f, 0.5f);
    float flashSpeed = 3f;
    bool damaged = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            damage_Indicator_Image.color = flashColor;
        }
        else
        {
            damage_Indicator_Image.color = Color.Lerp(damage_Indicator_Image.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void AddDamage(float damage)
    {
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;
        damaged = true;
        if (currentHealth <= 0)
        {
            causeDead();
        }
    }

    public void causeDead()
    {
        Instantiate(playerDeathFX, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        damage_Indicator_Image.color = flashColor;
        Destroy(gameObject);
    }
}
