using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : BaseEnemy
{
    [SerializeField] private float heathRegenerationPoints;
    [SerializeField] private float regenerationTick;

    private float maxHealth;

    public override void Awake()
    {
        base.Awake();
        maxHealth = health;
    }

    #region Overriden Methods
    public override void Update()
    {
        HealthModifier();
        base.Update();
    }

    private float nextActionTime = 0.0f;
    private void HealthModifier()
    {
        if (health < maxHealth)
        {
            // Example of health behaviour, zombies can slowly regenerate their health, by heathRegenerationQuantity every regenerationTick
            if (Time.time > nextActionTime)
            {
                nextActionTime += regenerationTick;

                // Clips the health to the max
                health = Mathf.Min(health + heathRegenerationPoints, maxHealth);

                Debug.Log(health);
                return;
            }
        }
    }
    #endregion
}
