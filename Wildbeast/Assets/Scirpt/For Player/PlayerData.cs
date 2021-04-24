using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerData : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update()
    {
        if (currentHealth == 0)
        {
            GameOverMenu.nowLevel = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(5);
        }
    }

    void OnCollisionEnter(Collision obj)
    {
        if (obj.collider.tag == "Enemy")
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
