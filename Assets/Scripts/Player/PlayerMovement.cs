using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D body;
    private SpriteRenderer playerSprite;

    private Vector2 movement;
    public Vector2 lastMoveDirection;
    private bool facingRight = true;


    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        lastMoveDirection = new Vector2(1, 0f); //sets initial direction for shooting projectiles
    }

    void Update()
    {
        GetPlayerInput();
        FlipByDirection();
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
        movement.Normalize();

        //gets last movement direction for shooting projectiles when player is not in movement
        if (movement.x != 0)
            lastMoveDirection = new Vector2(movement.x, 0f);

        if (movement.y != 0)
            lastMoveDirection = new Vector2(0f, movement.y);

        if (movement.x != 0 && movement.y != 0)
            lastMoveDirection = new Vector2(movement.x, movement.y);
    }

    void MovePlayer()
    {
        //normalize movement so we don't have the issue where moveSpeed is doubled when moving diagonally
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    #endregion

    #region Flip Sprite

    void FlipSprite()
    {
        playerSprite.flipX = !playerSprite.flipX;
        facingRight = !facingRight;
    }

    void FlipByDirection()
    {
        if ((movement.x == -1 && facingRight) ||
            (movement.x == 1 && !facingRight))
            FlipSprite();
    }

    #endregion
}
