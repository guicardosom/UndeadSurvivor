using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected float walkSpeed;
    [SerializeField] protected float baseHealthLevelMultiplier;
    [SerializeField] protected float health;
    [SerializeField] protected float attackPoints;
    [SerializeField] protected float level = 1;

    static protected Transform target; // Idea: Decoy or clone or something that changes the target temporarily
    protected SpriteRenderer sprite;
    protected Animator animator;

    public virtual void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        health = ((baseHealthLevelMultiplier * health) * level) ; // level allows us to recycle and increase difficulty, we can adjust this formula as needed when balancing
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
        MoveTowardsTarget();
    }

    protected virtual void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, walkSpeed / 10000);
    }

    public virtual void TakeDamage(float damage) // In the future we can implement Damage obj that has types where some enemies might be imune to
    {
        health = health - damage;
    }

    public virtual float Attack()
    {
        return attackPoints;
    }
    #endregion

    #region Private Methods
    private void LookAtTarget()
    {
        sprite.flipX = (transform.position.x - target.position.x > 0);
    }
    #endregion
}
