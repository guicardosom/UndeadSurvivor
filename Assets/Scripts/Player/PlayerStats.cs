using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField, Range(0.0f, 0.9f)] private float physicalResistance;
    //[SerializeField, Range(0.0f, 0.9f)] private float magicResistance;
    //[SerializeField, Range(0.0f, 0.9f)] private float poisonResistance;
     
    private float experience;
    private float experienceToNextLevel;
    private int level;

    public GameVariables gameVariables;
    public EventTrigger playerLevelUp;

    #region Private Methods
    private void Awake()
    {
        experienceToNextLevel = 100;
        experience = 0;
        level = 1;
        maxHealth = health;
    }

    private void Start()
    {

    }
    private void IncreaseLevel()
    {
        level++;
        gameVariables.IncreaveLevel();

        // Scale and modify Stats as we see fit when level up;
        experienceToNextLevel += (experienceToNextLevel * level / 10); // TODO: Come up with a better increase than this

        // Trigger Event
        playerLevelUp.TriggerEvent();
    }
    #endregion
    #region Public Methods
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

    public void IncreaseExperience(float exp) // to be called everytime we pickup XP gems
    {
        experience += exp;

        if (experience >= experienceToNextLevel)
        {
            experience = experienceToNextLevel - experience;
            IncreaseLevel();
        }
    }
    #endregion
    #region Events
    

    #endregion
}