using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    private bool llamado = false;


    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    /*  private void Update()
     {
        if (Input.GetKeyDown(KeyCode.Space))
         {
             TakeDamage(20);
         }
      }*/


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0 && !llamado)
        {
            Invoke("morir", 0.2f);
        }
    }


    void morir()
    {
        llamado = true;
        Destroy(gameObject);
        SceneManager.LoadScene("perder");
    }




}
