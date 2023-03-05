using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class BaseEnemy : MonoBehaviour
{
    // Properties are mostly protected to allow children to modify behaviour at will

    [SerializeField] protected Transform target;
    [SerializeField] protected float walkSpeed;
    [SerializeField] protected float baseHealthMultiplier;

    protected float maxHealth;
    protected float health;
    protected float level;

    protected SpriteRenderer sprite;
    protected Animator animator;

    // Use to connect an obj to it's own properties
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        SetHealth(baseHealthMultiplier * level); // level allows us to recycle and increase difficulty
        maxHealth = health;
    }

    // Use to connect the obj to other objs
    void Start()
    {
    }

    #region Virtual Methods
    
    // Virtualized for the sake of OOP
    public virtual void Update()
    {
        FlipSprite();
        MoveTowardsTarget();
    }

    // Common to every enemy, they move towards the target.
    // Each enemy script can implement their own behaviour on how they move by overriding this or just using the default follow. 
    protected virtual void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, walkSpeed / 10000);
    }

    // Each enemy can have their own health behavior by calling this method to set health
    protected virtual void SetHealth(float health)
    {
        this.health = health;
    }
    #endregion

    #region Private Methods
    // All enemies sprit will in a X axis point towards the player
    private void FlipSprite()
    {
        sprite.flipX = (transform.position.x - target.position.x > 0);
    }
    #endregion
}
