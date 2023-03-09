using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Profiling.RawFrameDataView;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected float walkSpeed;
    [SerializeField] protected float baseHealthLevelMultiplier;
    [SerializeField] protected float health;
    [SerializeField] protected float attackPoints;
    [SerializeField] protected float level = 1;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float experienceValue;

    protected static Transform target; 
    protected SpriteRenderer sprite;
    protected Animator animator;
    
    public DamageEvent playerTakeDamage;

    public virtual void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        health = ((baseHealthLevelMultiplier * health) * level);
    }

    public virtual void Start()
    {
        if(target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;      
    }
   
    #region Virtual Methods
    public virtual void Update()
    {
        LookAtTarget();
       
        if (!IsInAttackRange())
        {
            MoveTowardsTarget();
        }
    }

    public virtual void TakeDamage(Damage damage) // In the future we can implement Damage obj that has types where some enemies might be imune to
    {
        health -= damage.value;

        if(health <= 0) 
        {
            Die();
        }
    }
    
    public virtual Damage Attack()
    {
        return new Damage(attackPoints, DamageType.Magical);
    }

    protected virtual void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, walkSpeed / 10000);
    }
    #endregion

    #region Private Methods
    private void LookAtTarget()
    {
        sprite.flipX = (transform.position.x - target.position.x > 0);
    }

    protected bool IsInAttackRange()
    {
        return Vector3.Distance(transform.position, target.transform.position) < attackRange;
    }

    protected void Die()
    {
        // Drop EXP
        Exp instance = Resources.Load("Exp", typeof(GameObject)) as Exp;
        instance.ExperienceValue = experienceValue;
        Instantiate(instance, this.transform);

        Destroy(this);
    }
    #endregion

    #region Events
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            playerTakeDamage.TriggerEvent(Attack());
        }
    }
    #endregion
}
