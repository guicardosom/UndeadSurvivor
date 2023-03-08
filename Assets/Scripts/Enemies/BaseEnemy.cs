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
    [SerializeField] protected Damage damageData;
    [SerializeField] protected float attackRange;
    [SerializeField] protected int level = 1;

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
    }
    
    public virtual Damage Attack()
    {
        return new Damage(damageData.value, damageData.type);
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
    #endregion

    #region Events
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerTakeDamage.TriggerEvent(Attack());
        }
    }
    #endregion
}
