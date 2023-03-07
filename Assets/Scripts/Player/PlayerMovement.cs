using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject hand;
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D body;
    private SpriteRenderer playerSprite;
    private SpriteRenderer handSprite;

    private Vector2 movement;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        handSprite = hand.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        GetPlayerInput();
        GetMousePosition();
        RotateHandTowardsCursor();
        FlipSprite();
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

    #region Aim Rotation

    Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void RotateHandTowardsCursor()
    {
        //rotate hand to follow mouse position
        Vector2 lookDirection = GetMousePosition() - body.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        hand.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    #endregion

    #region Flip Sprite

    void FlipSprite()
    {
        //flip hand and player's sprites according to direction of movement
        if (movement.x == -1)
        {
            playerSprite.flipX = true;
            handSprite.flipX = true;
        }

        if (movement.x == 1)
        {
            playerSprite.flipX = false;
            handSprite.flipX = false;
        }
    }

    #endregion
}
