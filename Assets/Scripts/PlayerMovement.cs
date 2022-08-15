using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int jumpForce;
    [SerializeField] private float characterHeight;

    [SerializeField] private LayerMask groundCheck;

    private Rigidbody2D rb;

    private float moveInput;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, characterHeight, groundCheck.value);
        if (Input.GetKey(KeyCode.Space) && hit.collider != null)
        {
            Jump();
        }
    }

    private void Move()
    {
        moveInput = Input.GetAxis("Horizontal") * speed;
        Vector2 moveVector = new Vector2(moveInput * Time.fixedDeltaTime, rb.velocity.y);
        rb.velocity = moveVector;
    }

    private void Jump()
    {
        Vector2 jumpVector2 = Vector2.up * jumpForce;
        rb.AddForce(jumpVector2, ForceMode2D.Impulse);
    }
}
