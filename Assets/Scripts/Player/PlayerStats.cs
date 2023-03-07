using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float level;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField, Range(0.0f, 0.9f)] private float physicalResistance;
    //[SerializeField, Range(0.0f, 0.9f)] private float magicResistance;
    //[SerializeField, Range(0.0f, 0.9f)] private float poisonResistance;

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

    public void TakeDamage(Damage damage)
    {
        //float totalDamage = 0;
        //switch (damage.type)
        //{
        //    case DamageType.Magical:
        //      totalDamage += damage.value - (damage.value * magicResistance);
        //        break;
        //    case DamageType.Physical:
        //        totalDamage += damage.value - (damage.value * physicalResistance);
        //        break;
        //    case DamageType.Poison:
        //        totalDamage += damage.value - (damage.value * poisonResistance);
        //        break;
        //    default: 
        //        totalDamage += damage.value;
        //        break;
        //}
        //health -= totalDamage;

        health -= damage.value - (damage.value * physicalResistance);
    }
}