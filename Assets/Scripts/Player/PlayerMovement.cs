using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject rightHand;
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D body;
    private SpriteRenderer sprite;

    private Vector2 movement;
    private Vector2 mousePos;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        GetPlayerInput();
        GetMousePosition();
        RotateTowardsCursor();
        FlipSprite();
    }

    //moving player in FixedUpdate because it handles physics better
    void FixedUpdate()
    {
        MovePlayer();
    }

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

    void GetMousePosition()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void RotateTowardsCursor()
    {
        //rotate hand to follow mouse position
        Vector2 lookDirection = mousePos - body.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        rightHand.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void FlipSprite()
    {
        //flip hand and player's sprites according to direction of movement
        SpriteRenderer handSprite = rightHand.GetComponent<SpriteRenderer>();

        if (movement.x == -1)
        {
            sprite.flipX = true;
            handSprite.flipX = true;
        }

        if (movement.x == 1)
        {
            sprite.flipX = false;
            handSprite.flipX = false;
        }
    }
}
