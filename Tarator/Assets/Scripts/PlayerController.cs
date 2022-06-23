using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float health = 100f;
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    //public Sprite up_Sprite, down_Sprite, left_Sprite, right_Sprite, normal_Sprite;


    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>(); 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if(movementInput != Vector2.zero)
        {
            bool successMove = TryMove(movementInput);

            if(!successMove)
            {
                successMove = TryMove(new Vector2(movementInput.x, 0));
                if(!successMove)
                {
                successMove = TryMove(new Vector2(0, movementInput.y));
                }
            }
        }
        if(movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private bool TryMove(Vector2 direction)
    {
        int count = rb.Cast(
            direction,
            movementFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset);
            
        if(count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();

        /*if (Input.GetKeyDown(KeyCode.Up))
        {
            GetComponent<SpriteRenderer>().sprite = up_Sprite;
        }
        /*else if (Input.GetKeyDown(KeyCode.Right))
        {
            GetComponent<SpriteRenderer>().sprite = up_Sprite;
        }
        else if (Input.GetKeyDown(KeyCode.Down))
        {
            GetComponent<SpriteRenderer>().sprite = up_Sprite;
        }
        else if (Input.GetKeyDown(KeyCode.Left))
        {
            GetComponent<SpriteRenderer>().sprite = up_Sprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = normal_Sprite;
        }*/
    }
}
