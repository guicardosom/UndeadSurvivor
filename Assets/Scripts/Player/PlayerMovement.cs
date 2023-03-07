using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D body;
    private SpriteRenderer playerSprite;

    private Vector2 movement;
    private bool facingRight = true;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        GetPlayerInput();
        MovementDirection();
    }

    void FixedUpdate() //moving player in FixedUpdate because it handles physics better
    {
        MovePlayer();
    }

    #region Player Movement

    void GetPlayerInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        //normalize movement so we don't have the issue where moveSpeed is doubled when moving diagonally
        body.MovePosition(body.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    #endregion

    #region Flip Sprite

    void FlipSprite()
    {
        playerSprite.flipX = !playerSprite.flipX;
        facingRight = !facingRight;
    }

    void MovementDirection()
    {
        if ((movement.x == -1 && facingRight) ||
            (movement.x == 1 && !facingRight))
            FlipSprite();
    }

    #endregion
}
