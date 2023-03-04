using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D body;
    private Vector2 movement;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        getPlayerInput();
    }

    //moving player in FixedUpdate because it handles physics better
    void FixedUpdate()
    {
        movePlayer();
    }

    void getPlayerInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void movePlayer()
    {
        //normalize movement so we don't have the issue where moveSpeed is doubled when moving diagonally
        body.MovePosition(body.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
