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

    [SerializeField] private DamageEvent enemyTakeDamage;
    public static PlayerMovement pm { get; private set; }
    protected SpriteRenderer sprite;

    private float currentCooldown;

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

    #region Attack
    protected virtual void Attack()
    {
        GameObject spawnedWeapon = Instantiate(prefab);
        spawnedWeapon.transform.position = transform.position;
    }

    private void AttackAfterCooldown()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)
        {
            Attack();
            currentCooldown = Cooldown;
        }
    }

    protected virtual Damage DealDamage()
    {
        return new Damage(DamageData.value, DamageData.type);
    }
    #endregion

    #region Events
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyTakeDamage.TriggerEvent(DealDamage());
        }
    }
    #endregion
}