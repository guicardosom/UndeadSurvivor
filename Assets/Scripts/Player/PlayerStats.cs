using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float level;
    [SerializeField] public float health;
    [SerializeField] public float maxHealth;
    [Range(0.0f, 0.9f)] public float armour;

    private void Start()
    {
        maxHealth = health;
    }

    public void AddHealth(float health)
    {
       this.health = Mathf.Min(this.health + health, maxHealth);
    }

    public void IncreaseMaxHealth(float extraHealthPoints)
    {
        maxHealth += extraHealthPoints;
    }

    public void TakeDamage(float damage)
    {
        float totalDamage = 0;

        if(armour == 0)
        {
            totalDamage += damage;
        }
        else
        {
            totalDamage += damage - (damage * armour);
        }

        health -= damage;
    }
}