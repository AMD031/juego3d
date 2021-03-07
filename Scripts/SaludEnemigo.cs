using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludEnemigo : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;
    public HealthBar healthBar;
    public contador c;
    private bool llammado = false;

    private void Awake()
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

        if (currentHealth <= 0)
        {
            gameObject.GetComponent<EnemyIA>().muerto = true;
            /*if (!llammado)
            {
               llammado = true;*/

               Invoke("eliminarEnemigo", 3);
       /*     }*/
            
        }
    }

    void eliminarEnemigo()
    {
        c.disminuirCantidad();
        GameObject.Destroy(gameObject);
    }


}
