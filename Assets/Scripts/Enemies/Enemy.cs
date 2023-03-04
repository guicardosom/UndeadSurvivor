using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float walkSpeed;
    [SerializeField] private SpriteRenderer sprite;

    void Start()
    {
       
    }

    void Update()
    {
        Move();
        FlipSprite();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, walkSpeed/10000);
    }

    void FlipSprite()
    {
       sprite.flipX = (transform.position.x - target.position.x > 0);       
    }
}
