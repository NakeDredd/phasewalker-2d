using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private int speed;
    [SerializeField] private int jumpForce;
    [SerializeField] private float characterHeight;
    [SerializeField] private float coyoteTime;

    [SerializeField] private LayerMask groundCheck;

    private Rigidbody2D rb;

    private InputAction moving;

    private float coyoteTimeCounter;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moving = playerInput.actions["Movement"];

        playerInput.actions["Jump"].performed += Jump;
    }
    private void OnDisable()
    {
        playerInput.actions["Jump"].performed -= Jump;
    }

    private void Update()
    {
        Move(moving.ReadValue<Vector2>());

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    private void Move(Vector2 value)
    {
        Vector2 moveVector = new Vector2(0, 0);

        moveVector.x = value.x * speed * Time.fixedDeltaTime;

        moveVector.y = rb.velocity.y;

        rb.velocity = moveVector;
    }

    private void Jump(CallbackContext context)
    {
        if (coyoteTimeCounter > 0f)
        {
            Vector2 jumpVector2 = new Vector2(rb.velocity.x, jumpForce);
            rb.velocity = jumpVector2;
        }
        else if (IsGrounded())
        {
            coyoteTimeCounter = 0f;
        }
    }
    
    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, characterHeight, groundCheck.value).collider != null; 
    }
}
