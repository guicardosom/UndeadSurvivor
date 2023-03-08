using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected GameObject prefab;

    [Header("Weapon Stats")]
    [SerializeField] protected Damage DamageData;
    [SerializeField] protected int ProjectilesAmount;
    [field: SerializeField] public float AttackSpeed { get; protected set; }
    [SerializeField] protected float CycleDuration;
    [SerializeField] protected float Cooldown;
    [SerializeField] protected float Area;
    [SerializeField] protected int Level = 1;

    protected PlayerMovement pm;
    protected SpriteRenderer sprite;
    protected float currentCooldown;

    protected virtual void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        pm = FindObjectOfType<PlayerMovement>();
    }

    protected virtual void Start()
    {
        currentCooldown = Cooldown;
    }

    protected virtual void Update()
    {
        AttackAfterCooldown();
    }

    protected virtual Damage Attack()
    {
        currentCooldown = Cooldown;
        return new Damage(DamageData.value, DamageData.type);
    }

    private void AttackAfterCooldown()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)
            Attack();
    }
}