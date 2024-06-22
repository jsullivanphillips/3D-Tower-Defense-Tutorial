using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour
{
    public float totalHealth;

    public Slider healthBar;

    public int moneyOnDeath = 50;

    void Start()
    {
        healthBar.maxValue = totalHealth;
        healthBar.value = totalHealth;
        LevelManager.instance.activeEnemies.Add(this);
    }

    void Update()
    {
        healthBar.transform.rotation = Camera.main.transform.rotation;
    }



    public void TakeDamage(float damageToTake)
    {
        totalHealth -= damageToTake;
        if(totalHealth <= 0)
        {
            totalHealth = 0;
            Destroy(gameObject);
            
            MoneyManager.instance.AddMoney(moneyOnDeath);

            LevelManager.instance.activeEnemies.Remove(this);
        }
        healthBar.gameObject.SetActive(true);
        healthBar.value = totalHealth;
    }
}
